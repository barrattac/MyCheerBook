using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class StatusDAO
    {
        //Writes to database
        public void Write(string statement, SqlParameter[] parameters)
        {
            UserDAO userDao = new UserDAO();
            userDao.Write(statement, parameters);
        }

        //Reads database User's status
        public List<Status> ReadStatus(string statement, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MyCheerBook;Integrated Security=SSPI;"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(statement, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    SqlDataReader data = command.ExecuteReader();
                    List<Status> statuses = new List<Status>();
                    while (data.Read())
                    {
                        Status status = new Status();
                        status.ID = Convert.ToInt32(data["ID"]);
                        status.UserID = Convert.ToInt32(data["UserID"]);
                        status.Status = data["Status"].ToString();
                        status.Date = Convert.ToDateTime(data["Date"]);
                        statuses.Add(status);
                    }
                    try
                    {
                        return statuses;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }
    }
}
