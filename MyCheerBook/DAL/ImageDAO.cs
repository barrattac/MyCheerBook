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
        public void Write(string statement, SqlParameter[] parameters)
        {
            UserDAO userDao = new UserDAO();
            userDao.Write(statement, parameters);
        }
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
        public List<Image> GetAllImages()
        {
            return ReadImages("GetImages", null);
        }
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
    }
}
