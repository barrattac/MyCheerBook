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
        public void CreateUser(UserFM userFM)
        {
            UserDAO dao = new UserDAO();
            dao.CreateUser(ConvertUser(userFM));
        }
        public User ConvertUser(UserFM userFM)
        {
            User user = new User();
            user.FirstName = userFM.FirstName;
            user.LastName = userFM.LastName;
            user.Email = userFM.Email;
            user.Password = userFM.Password;
            return user;
        }
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
        public void ChangePassword(PasswordFM pass)
        {
            UserDAO dao = new UserDAO();
            User user = dao.GetUserByEmail(pass.Email);
            user.Password = pass.NewPass;
            dao.UpdateUser(user);
        }
        public UserVM GetUserByID(int userID)
        {
            UserDAO dao = new UserDAO();
            return ConvertUser(dao.GetUserByID(userID));
        }
        public ImageVM ConvertImage(Image image)
        {
            ImageVM vm = new ImageVM();
            vm.ID = image.ID;
            vm.Location = image.Location;
            vm.Title = image.Title;
            return vm;
        }
        public ImageVM GetProfileImage(UserVM vm)
        {
            ImageDAO dao = new ImageDAO();
            return ConvertImage(dao.GetProfileImage(vm.ProfileImage));
        }
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
        public bool ValidImageExt(string ext)
        {
            if(ext == ".gif" | ext == ".jpg" | ext == ".png")
            {
                return true;
            }
            return false;
        }
        public void AddImage(int userID, ImageFM fm)
        {
            ImageDAO dao = new ImageDAO();
            dao.AddImage(ConvertImage(fm));
            dao.CreateUserImage(userID, dao.GetImageByLocation(fm.Location).ID);
        }
        public Image ConvertImage(ImageFM fm)
        {
            Image image = new Image();
            image.Location = fm.Location;
            image.Title = fm.Title;
            return image;
        }
    }
}