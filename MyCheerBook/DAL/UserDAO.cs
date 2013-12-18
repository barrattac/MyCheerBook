using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class UserDAO
    {
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
        public void CreateUser(User user)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FirstName", user.FirstName),
                new SqlParameter("@LastName", user.LastName),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@Active", 1)
            };
            Write("CreateUser", parameters);
        }
        public List<User> GetAllUsers()
        {
            return ReadUsers("GetAllActiveUsers", null);
        }
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
        public void UpdateUser(User user)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", user.ID),
                new SqlParameter("@FirstName", user.FirstName),
                new SqlParameter("@LastName", user.LastName),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Password", user.Password)
            };
            Write("UpdateUser", parameters);
        }
    }
}
