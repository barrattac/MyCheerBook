using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class EventDAO
    {
        //Writes to database
        public void Write(string statement, SqlParameter[] parameters)
        {
            UserDAO userDao = new UserDAO();
            userDao.Write(statement, parameters);
        }

        //Reads from database for events
        public List<Event> ReadEvents(string statement, SqlParameter[] parameters)
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
                    List<Event> events = new List<Event>();
                    while (data.Read())
                    {
                        Event activity = new Event();
                        activity.ID = Convert.ToInt32(data["ID"]);
                        activity.EventName = data["Location"].ToString();
                        activity.Location = Convert.ToInt32(data["Location"]);
                        activity.Organizer = Convert.ToInt32(data["EventOrganizer"]);
                        activity.Registration = Convert.ToDateTime(data["RegistrationDeadline"]);
                        activity.Competition = Convert.ToDateTime(data["CompetitionDate"]);
                        activity.Details = data["Details"].ToString();
                        events.Add(activity);
                    }
                    try
                    {
                        return events;
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
