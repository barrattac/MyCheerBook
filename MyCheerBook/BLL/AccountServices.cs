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
    }
}