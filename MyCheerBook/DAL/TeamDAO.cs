﻿using System;
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
                    List<Teams> teams = new List<Teams>();
                    while (data.Read())
                    {
                        Teams team = new Teams();
                        team.ID = Convert.ToInt32(data["ID"]);
                        team.TeamName = data["TeamName"].ToString();
                        team.Coach = data["Coach"].ToString();
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
        public List<Teams> GetAllTeams()
        {
            return ReadTeams("ActiveTeams", null);
        }
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
    }
}
