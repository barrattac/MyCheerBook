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
        //Checks to see if a team with that name already exist in database
        public bool IsExistingTeam(string teamName)
        {
            TeamDAO dao = new TeamDAO();
            if (dao.GetTeamByName(teamName) == null)
            {
                return false;
            }
            return true;
        }

        //Creates Team and adds to User's Teams
        public void CreateTeam(TeamFM teamFM, int UserID)
        {
            TeamDAO dao = new TeamDAO();
            dao.CreateTeam(ConvertTeam(teamFM));
            dao.AddUserTeam(UserID, dao.GetTeamByName(teamFM.TeamName).ID);
        }

        //Converts From into Team
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

        //Converts Team into View Model
        public TeamVM ConvertTeam(Teams team)
        {
            TeamVM vm = new TeamVM();
            vm.ID = team.ID;
            vm.TeamName = team.TeamName;
            vm.Coach = team.Coach;
            vm.Email = team.Email;
            vm.Phone = team.Phone;
            vm.Line1 = team.Line1;
            vm.Line2 = team.Line2;
            vm.City = team.City;
            vm.State = team.State;
            vm.Zip = team.Zip;
            vm.Web = team.Web;
            return vm;
        }

        //Gets list of user's teams
        public TeamsVM GetUserTeams(int userID)
        {
            TeamDAO dao = new TeamDAO();
            TeamsVM list = new TeamsVM();
            List<TeamVM> vm = new List<TeamVM>();
            foreach (Teams team in dao.GetUserTeams(userID))
            {
                vm.Add(ConvertTeam(team));
            }
            list.Teams = vm;
            return list;
        }

        //Gets team's images
        public List<ImageVM> GetTeamImages(int teamID)
        {
            ImageDAO dao = new ImageDAO();
            AccountServices log = new AccountServices();
            return log.ConvertImages(dao.GetTeamImages(teamID)).Images;
        }

        //Gets a random location for a team image
        public string RandomImage(int teamID)
        {
            if (GetTeamImages(teamID) == null || GetTeamImages(teamID).Count == 0)
            {
                return null;
            }
            Random rng = new Random();
            int number = rng.Next(GetTeamImages(teamID).Count);
            return GetTeamImages(teamID)[number].Location;
        }

        //Gets team by team ID
        public TeamVM GetTeamByID(int teamID)
        {
            TeamDAO dao = new TeamDAO();
            return ConvertTeam(dao.GetTeamByID(teamID));
        }

        //Gets a list of team members for a team
        public List<UserVM> GetTeamMembers(int teamID)
        {
            UserDAO dao = new UserDAO();
            AccountServices log = new AccountServices();
            return log.ConvertUsers(dao.GetTeamMembers(teamID));
        }

        //Determines if a user is part of a team
        public bool IsExistingTeamMember(int userID, int teamID)
        {
            foreach (UserVM vm in GetTeamMembers(teamID))
            {
                if (vm.ID == userID)
                {
                    return true;
                }
            }
            return false;
        }

        //Determines if the user and team email match(if no team email exist, it returns if they are a team member)
        public bool Permissions(int userID, int teamID)
        {
            UserDAO dao = new UserDAO();
            if (GetTeamByID(teamID).Email == null)
            {
                return IsExistingTeamMember(userID, teamID);
            }
            if (dao.GetUserByID(userID).Email == GetTeamByID(teamID).Email)
            {
                return true;
            }
            return false;
        }

        //Deletes Image from a team
        public void DeleteImage(int imageID, int teamID)
        {
            ImageDAO dao = new ImageDAO();
            dao.DeleteTeamImage(imageID, teamID);
        }

        //Add Images to database(images and userImages)
        public void AddImage(int teamID, ImageFM fm)
        {
            ImageDAO dao = new ImageDAO();
            AccountServices log = new AccountServices();
            dao.AddImage(log.ConvertImage(fm));
            dao.CreateTeamImage(teamID, dao.GetImageByLocation(fm.Location).ID);
        }

        //Gets team's videos
        public List<VideoVM> GetTeamVideos(int teamID)
        {
            VideoDAO dao = new VideoDAO();
            AccountServices log = new AccountServices();
            return log.ConvertVideos(dao.GetTeamVideos(teamID));
        }

        //Deletes Video from a team
        public void DeleteVideo(int videoID, int teamID)
        {
            VideoDAO dao = new VideoDAO();
            dao.DeleteTeamVideo(videoID, teamID);
        }
    }
}