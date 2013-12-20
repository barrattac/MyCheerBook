using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class TeamServices
    {

        public bool IsExistingTeam(string teamName)
        {
            TeamDAO dao = new TeamDAO();
            if (dao.GetTeamByName(teamName) == null)
            {
                return false;
            }
            return true;
        }
        public void CreateTeam(TeamFM teamFM)
        {
            TeamDAO dao = new TeamDAO();
            dao.CreateTeam(ConvertTeam(teamFM));
        }
        public Teams ConvertTeam(TeamFM teamFM)
        {
            Teams team = new Teams();
            team.TeamName = teamFM.TeamName;
            team.Coach = teamFM.Coach;
            team.Email = teamFM.Email;
            team.Phone = teamFM.Phone;
            team.Line1 = teamFM.Line1;
            team.Line2 = teamFM.Line2;
            team.City = teamFM.City;
            team.State = teamFM.State;
            team.Zip = teamFM.Zip;
            team.Web = teamFM.Web;
            return team;
        }
    }
}
