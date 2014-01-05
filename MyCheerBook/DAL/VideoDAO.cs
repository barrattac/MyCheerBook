using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class VideoDAO
    {
        //Writes to database
        public void Write(string statement, SqlParameter[] parameters)
        {
            UserDAO userDao = new UserDAO();
            userDao.Write(statement, parameters);
        }

        //Reads from database for Video
        public List<Video> ReadVideos(string statement, SqlParameter[] parameters)
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
                    List<Video> videos = new List<Video>();
                    while (data.Read())
                    {
                        Video video = new Video();
                        video.ID = Convert.ToInt32(data["ID"]);
                        video.Location = data["Location"].ToString();
                        video.Title = data["Title"].ToString();
                        videos.Add(video);
                    }
                    try
                    {
                        return videos;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }

        //Gets all images
        public List<Video> GetAllVideos()
        {
            return ReadVideos("GetVideos", null);
        }

        //Gets list of user's videos
        public List<Video> GetUserVideos(int userID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userID)
            };
            return ReadVideos("GetUserVideos", parameters);
        }

        //Add video to database
        public void AddVideo(Video video)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Location", video.Location),
                new SqlParameter("@Title", video.Title)
            };
            Write("AddVideo", parameters);
        }

        //Gets Video by file path
        public Video GetVideoByLocation(string location)
        {
            foreach (Video video in GetAllVideos())
            {
                if (video.Location == location)
                {
                    return video;
                }
            }
            return null;
        }

        //Add video to user's video
        public void CreateUserImage(int userID, int videoID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userID),
                new SqlParameter("@VideoID", videoID)
            };
            Write("AddUserVideo", parameters);
        }
    }
}