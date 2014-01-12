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
        //Determines if two IDs are Friends
        public bool Friends(int userID, int friendID)
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

        //UnFriends someone
        public void UnFriend(int userID, int friendID)
        {
            UserDAO dao = new UserDAO();
            dao.UnFriend(userID, friendID);
        }

        //Friends someone
        public void MakeFriends(int userID, int friendID)
        {
            UserDAO dao = new UserDAO();
            dao.MakeFriends(userID, friendID);
        }
    }
}
