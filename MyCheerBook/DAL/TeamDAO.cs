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
        //Writes to database
        public void Write(string statement, SqlParameter[] parameters)
        {
            UserDAO userDao = new UserDAO();
            userDao.Write(statement, parameters);
        }

        //Reads database for teams
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
                    List<Teams> teams = new List<Teams>();
                    while (data.Read())
                    {
                        Teams team = new Teams();
                        team.ID = Convert.ToInt32(data["ID"]);
                        team.TeamName = data["TeamName"].ToString();
                        team.Coach = data["CoachName"].ToString();
                        team.Email = data["Email"].ToString();
                        team.Phone = data["Phone"].ToString();
                        team.Line1 = data["Line1"].ToString();
                        team.Line2 = data["Line2"].ToString();
                        team.City = data["City"].ToString();
                        team.State = data["State"].ToString();
                        team.Zip = Convert.ToInt32(data["Zip"]);
                        teams.Add(team);
                    }
                    try
                    {
                        return teams;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }

        //Gets list of all teams
        public List<Teams> GetAllTeams()
        {
            return ReadTeams("ActiveTeams", null);
        }

        //Gets team by team name
        public Teams GetTeamByName(string teamName)
        {
            List<Teams> teams = GetAllTeams();
            foreach (Teams team in teams)
            {
                if (team.TeamName == teamName)
                {
                    return team;
                }
            }
            return null;
        }

        //Add team to database
        public void CreateTeam(Teams team)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TeamName", team.TeamName),
                new SqlParameter("@CoachName", team.Coach),
                new SqlParameter("@Email", team.Email),
                new SqlParameter("@Phone", team.Phone),
                new SqlParameter("@Line1", team.Line1),
                new SqlParameter("@Line2", team.Line2),
                new SqlParameter("@City", team.City),
                new SqlParameter("@State", team.State),
                new SqlParameter("@Zip", team.Zip),
                new SqlParameter("@Active", 1)
            };
            Write("CreateTeam", parameters);
        }

        //Updates team information
        public void UpdateTeam(Teams team)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", team.ID),
                new SqlParameter("@TeamName", team.TeamName),
                new SqlParameter("@Coach", team.Coach),
                new SqlParameter("@Email", team.Email),
                new SqlParameter("@Phone", team.Phone),
                new SqlParameter("@Line1", team.Line1),
                new SqlParameter("@Line2", team.Line2),
                new SqlParameter("@City", team.City),
                new SqlParameter("@State", team.State),
                new SqlParameter("@Zip", team.Zip)
            };
            Write("UpdateTeam", parameters);
        }

        //Add teams to user's teams
        public void AddUserTeam(int userID, int teamID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userID),
                new SqlParameter("@TeamID", teamID)
            };
            Write("AddUserTeam", parameters);
        }

        //Gets list of user's teams
        public List<Teams> GetUserTeams(int userID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userID)
            };
            return ReadTeams("GetUserTeams", parameters);
        }

        //Search Teams
        public List<Teams> SearchTeams(string word)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Word", word)
            };
            return ReadTeams("SearchTeams", parameters);
        }
    }
}
