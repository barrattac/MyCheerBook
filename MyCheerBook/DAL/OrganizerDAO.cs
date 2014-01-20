using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class OrganizerDAO
    {
        //Writes to database
        public void Write(string statement, SqlParameter[] parameters)
        {
            UserDAO userDao = new UserDAO();
            userDao.Write(statement, parameters);
        }

        //Reads from database for Event Organizers
        public List<Oranizers> ReadEventOrganizer(string statement, SqlParameter[] parameters)
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
                    List<Oranizers> eventOrganizers = new List<Oranizers>();
                    while (data.Read())
                    {
                        Oranizers eventOrganizer = new Oranizers();
                        eventOrganizer.ID = Convert.ToInt32(data["ID"]);
                        eventOrganizer.CompanyName = data["CompanyName"].ToString();
                        eventOrganizer.Email = data["Email"].ToString();
                        eventOrganizer.Password = data["Password"].ToString();
                        eventOrganizer.Contact = Convert.ToInt32(data["ContactInfo"]);
                        eventOrganizers.Add(eventOrganizer);
                    }
                    try
                    {
                        return eventOrganizers;
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
