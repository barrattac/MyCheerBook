﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class StatusServices
    {
        //Updates a user's status
        public void AddStatus(StatusFM fm)
        {
            StatusDAO dao = new StatusDAO();
            dao.AddStatus(ConvertStatus(fm));
        }

        //Gets a list of status to display (returns null if not friends)
        public List<StatusVM> GetStatus(int userID, int currentProfile)
        {
            FriendServices fs = new FriendServices();
            if (userID == currentProfile)
            {
                //get all status(combined list of your's and friends' status)
                return UserStatus(userID);
            }
            if (fs.Friends(userID, currentProfile) == 2)
            {
                //get status for friend
                return GetStatus(currentProfile);
            }
            //Not friends so you can see status for this user
            return null;
        }

        //Get one user's status
        public List<StatusVM> GetStatus(int userID)
        {
            StatusDAO dao = new StatusDAO();
            return ConvertStatus(dao.GetStatus(userID));
        }

        //Get status for you and friends
        public List<StatusVM> UserStatus(int userID)
        {
            StatusDAO dao = new StatusDAO();
            List<Status> status = dao.GetFriendStatus(userID);
            return CombineStatus(CombineStatus(ConvertStatus(dao.GetFriendStatus(userID)), ConvertStatus(dao.GetFriendStatus2(userID))), GetStatus(userID));
        }

        //Combines users status with friends status
        private List<StatusVM> CombineStatus(List<StatusVM> friendStatus, List<StatusVM> userStatus)
        {
            List<StatusVM> combinedList = new List<StatusVM>();
            while (friendStatus.Count != 0 && userStatus.Count != 0)
            {
                if (friendStatus[0].Date > userStatus[0].Date)
                {
                    combinedList.Add(friendStatus[0]);
                    friendStatus.RemoveAt(0);
                }
                else
                {
                    combinedList.Add(userStatus[0]);
                    userStatus.RemoveAt(0);
                }
            }
            if (friendStatus.Count == 0)
            {
                combinedList.AddRange(userStatus);
            }
            else
            {
                combinedList.AddRange(friendStatus);
            }
            return combinedList;
        }

        //Converts fm into Status
        public Status ConvertStatus(StatusFM fm)
        {
            StatusDAO dao = new StatusDAO();
            Status status = new Status();
            status.UserID = fm.UserID;
            status.Message = fm.Message;
            status.Date = DateTime.Now;
            return status;
        }

        //Converts a list of status into list of vm
        public List<StatusVM> ConvertStatus(List<Status> list)
        {
            List<StatusVM> vm = new List<StatusVM>();
            foreach (Status status in list)
            {
                vm.Add(ConvertStatus(status));
            }
            return vm;
        }

        //Converts Status into VM 
        public StatusVM ConvertStatus(Status status)
        {
            StatusVM vm = new StatusVM();
            vm.ID = status.ID;
            vm.UserID = status.UserID;
            vm.Message = status.Message;
            vm.Date = status.Date;
            return vm;
        }

        //Convert DateTime to String for viewing
        public string ConvertDate(DateTime dt)
        {
            string format = "ddd MMM d HH:mm yyyy";
            TimeSpan passed = (DateTime.Now - dt);
            return ConvertPassed(passed) + dt.ToString(format);
        }
        
        //Convert Passed Time to a string
        public string ConvertPassed(TimeSpan passed)
        {
            if (passed.TotalMinutes < 60)
            {
                return Convert.ToInt32(passed.TotalMinutes) + " mins ago. ";
            }
            else if (passed.TotalHours < 24)
            {
                return Convert.ToInt32(passed.TotalHours) + " hrs ago. ";
            }
            return Convert.ToInt32(passed.TotalDays) + " days ago. ";
        }

        //Upadates News for a Team
        public void UpdateTeamNews(int teamID, StatusFM news)
        {
            StatusDAO dao = new StatusDAO();
            dao.UpdateTeamNews(teamID, ConvertStatus(news));
        }

        //Gets a list of Status(Team News) for a team if the user is part of the team
        public List<StatusVM> GetTeamNews(int userID, int teamID)
        {
            List<StatusVM> vm = new List<StatusVM>();
            TeamServices log = new TeamServices();
            StatusDAO dao = new StatusDAO();
            if(log.IsExistingTeamMember(userID, teamID))
            {
                return ConvertStatus(dao.GetTeamNews(teamID));
            }
            return vm;
        }
    }
}
