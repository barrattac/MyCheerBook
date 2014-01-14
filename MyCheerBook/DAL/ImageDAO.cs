using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class ImageDAO
    {
        //Writes to database
        public void Write(string statement, SqlParameter[] parameters)
        {
            UserDAO userDao = new UserDAO();
            userDao.Write(statement, parameters);
        }

        //Reads from database for images
        public List<Image> ReadImages(string statement, SqlParameter[] parameters)
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
                    List<Image> images = new List<Image>();
                    while (data.Read())
                    {
                        Image image = new Image();
                        image.ID = Convert.ToInt32(data["ID"]);
                        image.Location = data["Location"].ToString();
                        image.Title = data["Title"].ToString();
                        images.Add(image);
                    }
                    try
                    {
                        return images;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }

        //Gets all images
        public List<Image> GetAllImages()
        {
            return ReadImages("GetImages", null);
        }

        //Gets profile image
        public Image GetProfileImage(int profileImage)
        {
            foreach (Image image in GetAllImages())
            {
                if (image.ID == profileImage)
                {
                    return image;
                }
            }
            return GetAllImages()[0];
        }
        
        //Gets list of user's images
        public List<Image> GetUserImages(int userID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userID)
            };
            return ReadImages("GetUserImages", parameters);
        }
        
        //Add image to database
        public void AddImage(Image image)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Location", image.Location),
                new SqlParameter("@Title", image.Title)
            };
            Write("AddImage", parameters);
        }
        
        //Gets Image by file path
        public Image GetImageByLocation(string location)
        {
            foreach(Image image in GetAllImages())
            {
                if(image.Location == location)
                {
                    return image;
                }
            }
            return null;
        }
        
        //Add image to user's images
        public void CreateUserImage(int userID, int imageID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userID),
                new SqlParameter("@ImageID", imageID)
            };
            Write("AddUserImage", parameters);
        }

        //Add image to team's images
        public void CreateTeamImage(int teamID, int imageID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TeamID", teamID),
                new SqlParameter("@ImageID", imageID)
            };
            Write("AddTeamImage", parameters);
        }
        
        //Deletes image from user's images
        public void DeleteUserImage(int userID, int imageID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userID),
                new SqlParameter("@ImageID", imageID)
            };
            Write("DeleteUserImages", parameters);
        }

        //Gets All Images for a team
        public List<Image> GetTeamImages(int teamID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TeamID", teamID)
            };
            return ReadImages("GetTeamImages", parameters);
        }

        //Deletes image from user's images
        public void DeleteTeamImage(int imageID, int teamID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TeamID", teamID),
                new SqlParameter("@ImageID", imageID)
            };
            Write("DeleteTeamImages", parameters);
        }
    }
}
