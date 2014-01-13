using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class FriendServices
    {
        //Determines friend status (0 not friends, 1 requested, 2 friends)
        public int Friends(int userID, int friendID)
        {
            if (AlreadyFriends(userID, friendID))
            {
                return 2;
            }
            if (Requested(userID, friendID))
            {
                return 1;
            }
            return 0;
        }

        //Determines if two IDs are Friends
        public bool AlreadyFriends(int userID, int friendID)
        {
            UserDAO dao = new UserDAO();
            foreach (User user in dao.GetAllFriends(userID))
            {
                if (user.ID == friendID)
                {
                    return true;
                }
            }
            return false;
        }

        //Determines if friend request was already sent
        public bool Requested(int userID, int friendID)
        {
            UserDAO dao = new UserDAO();
            foreach (User user in dao.GetFriendRequest(userID))
            {
                if (user.ID == friendID)
                {
                    return true;
                }
            }
            foreach (User user in dao.FriendsYouRequested(userID))
            {
                if (user.ID == friendID)
                {
                    return true;
                }
            }
            return false;
        }

        //UnFriends someone
        public void UnFriend(int userID, int friendID)
        {
            UserDAO dao = new UserDAO();
            dao.UnFriend(userID, friendID);
        }

        //Sends a friend request someone
        public void SendRequest(int userID, int friendID)
        {
            UserDAO dao = new UserDAO();
            dao.SendRequest(userID, friendID);
        }

        //Accepts Friend Request
        public void MakeFriends(int userID, int friendID)
        {
            UserDAO dao = new UserDAO();
            dao.MakeFriends(userID, friendID);
        }

        //Returns number of pending friend request (Just the one's waiting on your response)
        public int PendingRequest(int userID)
        {
            UserDAO dao = new UserDAO();
            return dao.GetFriendRequest(userID).Count();
        }

        //Returns list of friends waiting on a response from you
        public List<UserVM> YourRequest(int userID)
        {
            UserDAO dao = new UserDAO();
            return ConvertUsers(dao.GetFriendRequest(userID));
        }

        //Returns list of friends your waiting on a response from
        public List<UserVM> WaitingResponse(int userID)
        {
            UserDAO dao = new UserDAO();
            return ConvertUsers(dao.FriendsYouRequested(userID));
        }

        //Converts a list of users to VM
        public List<UserVM> ConvertUsers(List<User> users)
        {
            List<UserVM> vm = new List<UserVM>();
            AccountServices log = new AccountServices();
            foreach (User user in users)
            {
                vm.Add(log.ConvertUser(user));
            }
            return vm;
        }
        
        //Gets a list of all your friends
        public List<UserVM> GetFriends(int userID)
        {
            UserDAO dao = new UserDAO();
            return ConvertUsers(dao.GetAllFriends(userID));
        }
    }
}
