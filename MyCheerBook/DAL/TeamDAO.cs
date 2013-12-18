using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class TeamDAO
    {
        public void Write(string statement, SqlParameter[] parameters)
        {
            UserDAO userDao = new UserDAO();
            userDao.Write(statement, parameters);
        }
        public List<Teams> ReadTeams(string statement, SqlParameter[] parameters)
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
                    List<Teams> users = new List<Teams>();
                    while (data.Read())
                    {

                        //Need to work on
                        User user = new User();
                        user.ID = Convert.ToInt32(data["ID"]);
                        user.FirstName = data["FirstName"].ToString();
                        user.LastName = data["LastName"].ToString();
                        user.Email = data["Email"].ToString();
                        user.Password = data["Password"].ToString();
                        users.Add(user);
                    }
                    try
                    {
                        return users;
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
