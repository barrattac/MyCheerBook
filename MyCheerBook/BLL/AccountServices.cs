using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class AccountServices
    {
        //Checks Users to see if email is already in use
        public bool IsExistingUser(string email)
        {
            UserDAO dao = new UserDAO();
            if (dao.GetUserByEmail(email) == null)
            {
                return false;
            }
            return true;
        }
        
        //Checks if it is an valid Email
        public bool ValidEmail(string email)
        {
            if (email.Length < 255)
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        
        //Creates a User when Registrating
        public void CreateUser(UserFM userFM)
        {
            UserDAO dao = new UserDAO();
            dao.CreateUser(ConvertUser(userFM));
        }
        
        //Converts Registration From into a user
        public User ConvertUser(UserFM userFM)
        {
            User user = new User();
            user.FirstName = userFM.FirstName;
            user.LastName = userFM.LastName;
            user.Email = userFM.Email;
            user.Password = userFM.Password;
            return user;
        }

        //Logs User In
        public UserVM Login(UserFM userFM)
        {
            UserDAO dao = new UserDAO();
            User user = dao.GetUserByEmail(userFM.Email);
            if (user.Password == userFM.Password)
            {
                UserVM userVM = ConvertUser(user);
                return userVM;
            }
            return null;
        }
        
        //Converts User to a View Model
        public UserVM ConvertUser(User user)
        {
            UserVM userVM = new UserVM();
            userVM.ID = user.ID;
            userVM.FirstName = user.FirstName;
            userVM.LastName = user.LastName;
            userVM.Email = user.Email;
            userVM.ProfileImage = user.ProfileImage;
            return userVM;
        }
        
        //Checks Password Requirements
        public bool ValidPassword(string pass)
        {
            if (pass != null && pass.Length > 7 && pass.Length < 100)
            {
                return true;
            }
            return false;
        }
        
        //Makes sure password and confirm match and that they meet requirements
        public bool ValidPasswords(PasswordFM pass)
        {
            UserDAO dao = new UserDAO();
            if (pass.Email != null && IsExistingUser(pass.Email) && dao.GetUserByEmail(pass.Email).Password == pass.CurrentPass
                && ValidPassword(pass.NewPass) && pass.NewPass == pass.ConfirmPass)
            {
                return true;
            }
            return false;
        }

        //Changes User's Password
        public void ChangePassword(PasswordFM pass)
        {
            UserDAO dao = new UserDAO();
            User user = dao.GetUserByEmail(pass.Email);
            user.Password = pass.NewPass;
            dao.UpdateUser(user);
        }

        //Returns a user when ID is input
        public UserVM GetUserByID(int userID)
        {
            UserDAO dao = new UserDAO();
            return ConvertUser(dao.GetUserByID(userID));
        }

        //Converts Image to a View Model
        public ImageVM ConvertImage(Image image)
        {
            ImageVM vm = new ImageVM();
            vm.ID = image.ID;
            vm.Location = image.Location;
            vm.Title = image.Title;
            return vm;
        }

        //Gets View Model for User Profile Image
        public ImageVM GetProfileImage(UserVM vm)
        {
            ImageDAO dao = new ImageDAO();
            return ConvertImage(dao.GetProfileImage(vm.ProfileImage));
        }

        //Gets Images for User
        public ImagesVM GetUserImages(int userID)
        {
            ImageDAO dao = new ImageDAO();
            ImagesVM vm = new ImagesVM();
            List<ImageVM> images = new List<ImageVM>();
            foreach (Image image in dao.GetUserImages(userID))
            {
                images.Add(ConvertImage(image));
            }
            vm.Images = images;
            return vm;
        }

        //return a random string, possible 15,721,205,760 unquie strings
        //used for producing rng fileName for uploads
        public string RngString()
        {
            {
                Random rng = new Random();
                string rngString = "" + Convert.ToChar(rng.Next(97, 123)) + Convert.ToChar(rng.Next(48,58));
                for (int i = 0; i < 5; i++)
                {
                    int dec = rng.Next(2);
                    switch (dec)
                    {
                        case 0: // number
                            rngString = rngString + Convert.ToChar(rng.Next(48, 58));
                            break;
                        case 1:  // lower case
                            rngString = rngString + Convert.ToChar(rng.Next(97, 123));
                            break;
                    }
                }
                return rngString;
            }
        }

        //Makes sure Uploaded Image is a valid image extention
        public bool ValidImageExt(string ext)
        {
            if(ext == ".gif" | ext == ".jpg" | ext == ".png")
            {
                return true;
            }
            return false;
        }

        //Add Images to database(images and userImages)
        public void AddImage(int userID, ImageFM fm)
        {
            ImageDAO dao = new ImageDAO();
            dao.AddImage(ConvertImage(fm));
            dao.CreateUserImage(userID, dao.GetImageByLocation(fm.Location).ID);
        }
        
        //Converts From into a Image
        public Image ConvertImage(ImageFM fm)
        {
            Image image = new Image();
            image.Location = fm.Location;
            image.Title = fm.Title;
            return image;
        }

        //Deletes Image from User
        public void DeleteUserImage(int userID, int imageID)
        {
            ImageDAO dao = new ImageDAO();
            dao.DeleteUserImage(userID, imageID);
        }

        //Gets Videos for User
        public VideosVM GetUserVideos(int userID)
        {
            VideoDAO dao = new VideoDAO();
            VideosVM vm = new VideosVM();
            List<VideoVM> videos = new List<VideoVM>();
            foreach (Video video in dao.GetUserVideos(userID))
            {
                videos.Add(ConvertVideo(video));
            }
            vm.Videos = videos;
            return vm;
        }

        //Converts Video into View Model
        public VideoVM ConvertVideo(Video video)
        {
            VideoVM vm = new VideoVM();
            vm.ID = video.ID;
            vm.Location = video.Location;
            vm.Title = video.Title;
            return vm;
        }

        //Makes sure Uploaded Video is a valid video extention
        public bool ValidVideoExt(string ext)
        {
            if (ext == ".mp4" | ext == ".webm" | ext == ".ogv")
            {
                return true;
            }
            return false;
        }

        //Add Video to database(Videos and userVideos)
        public void AddVideo(int userID, VideoFM fm)
        {
            VideoDAO dao = new VideoDAO();
            dao.AddVideo(ConvertVideo(fm));
            dao.CreateUserVideo(userID, dao.GetVideoByLocation(fm.Location).ID);
        }

        //Converts From into a Video
        public Video ConvertVideo(VideoFM fm)
        {
            Video video = new Video();
            video.Location = fm.Location;
            video.Title = fm.Title;
            return video;
        }
    }
}