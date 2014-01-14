﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class UserDAO
    {
        //Writes to database
        public void Write(string statement, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MyCheerBook;Integrated Security=SSPI;"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(statement, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);
                    command.ExecuteNonQuery();
                }
            }
        }

        //Reads database users
        public List<User> ReadUsers(string statement, SqlParameter[] parameters)
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
                    List<User> users = new List<User>();
                    while (data.Read())
                    {
                        User user = new User();
                        user.ID = Convert.ToInt32(data["ID"]);
                        user.FirstName = data["FirstName"].ToString();
                        user.LastName = data["LastName"].ToString();
                        user.Email = data["Email"].ToString();
                        user.Password = data["Password"].ToString();
                        user.ProfileImage = Convert.ToInt32(data["ProfileImage"]);
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

        //Add user to database
        public void CreateUser(User user)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FirstName", user.FirstName),
                new SqlParameter("@LastName", user.LastName),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@ProfileImage", 1),
                new SqlParameter("@Active", 1)
            };
            Write("CreateUser", parameters);
        }

        //Get list of users
        public List<User> GetAllUsers()
        {
            return ReadUsers("ActiveUsers", null);
        }

        //Gets user by email
        public User GetUserByEmail(string email)
        {
            List<User> users = GetAllUsers();
            foreach (User user in users)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }

        //Gets user by ID
        public User GetUserByID(int ID)
        {
            List<User> users = GetAllUsers();
            foreach (User user in users)
            {
                if (user.ID == ID)
                {
                    return user;
                }
            }
            return null;
        }

        //Updates user's information
        public void UpdateUser(User user)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", user.ID),
                new SqlParameter("@FirstName", user.FirstName),
                new SqlParameter("@LastName", user.LastName),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@ProfileImage", user.ProfileImage),
                new SqlParameter("@Active", 1)
            };
            Write("UpdateUser", parameters);
        }

        //Search Users
        public List<User> SearchUsers(string word)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Word", word)
            };
            return ReadUsers("SearchUsers", parameters);
        }

        //Gets a list of friends for a user
        public List<User> GetAllFriends(int userID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userID)
            };
            return ReadUsers("GetFriends", parameters);
        }

        //Get a list of friends that requested you(request not accept or denied)
        public List<User> GetFriendRequest(int userID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userID)
            };
            return ReadUsers("GetFriendRequest", parameters);
        }

        //Get a list of friends that you requested(request not accept or denied)
        public List<User> FriendsYouRequested(int userID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userID)
            };
            return ReadUsers("FriendsYouRequested", parameters);
        }

        //UnFriends someone
        public void UnFriend(int userID, int friendID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userID),
                new SqlParameter("@FriendID", friendID)
            };
            Write("UnFriend", parameters);
        }

        //Sends a friend request
        public void SendRequest(int userID, int friendID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userID),
                new SqlParameter("@FriendID", friendID)
            };
            Write("RequestFriends", parameters);
        }

        //Accept friend request
        public void MakeFriends(int userID, int friendID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userID),
                new SqlParameter("@FriendID", friendID)
            };
            Write("MakeFriends", parameters);
        }

        //Gets a list of team members for a team
        public List<User> GetTeamMembers(int teamID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TeamID", teamID)
            };
            return ReadUsers("GetTeamMembers", parameters);
        }
    }
}