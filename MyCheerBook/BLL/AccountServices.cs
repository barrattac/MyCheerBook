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
            List<User> users = dao.GetAllUsers();
            foreach (User user in users)
            {
                if (user.Email == email)
                {
                    return true;
                }
            }
            return false;
        }
            //Checks if it is an valid Email
        public bool ValidEmail(string email)
        {
            if (email.Length < 100)
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
            return userVM;
        }
            //Checks Password Requirements
        public bool ValidPassword(string pass)
        {
            if (pass != null && pass.Length > 7)
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
    }
}