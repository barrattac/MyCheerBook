﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using DAL;

namespace BLL
{
    public class MailServices
    {
        //Actually Sends the Email
        public void SendMail(MailFM mailFM)
        {
            MailMessage mail = new MailMessage();
            List<string> emailList = SplitEmails(mailFM.To);
            foreach (string email in emailList)
            {
                mail.To.Add(email);
                mail.From = new MailAddress(mailFM.From);
                mail.Subject = mailFM.Subject;
                mail.Body = mailFM.Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential
                (mailFM.From, "My2Cheer5Book4");// Username and password for accont used for sending emails
                smtp.EnableSsl = true;
                smtp.Send(mail);
                mail.To.Clear();
            }
        }
        //Splits a string of Emails into a list
        public List<string> SplitEmails(string emails)
        {
            List<string> emailList = new List<string>();
            bool multiplemail = true;
            while (multiplemail)
            {
                string mailadd = "";
                if (emails.Contains(','))
                {
                    int mailindex = emails.IndexOf(',');
                    mailadd = emails.Substring(0, mailindex);
                    emails = emails.Substring(mailindex + 1);
                    emailList.Add(mailadd);
                }
                else
                {
                    emailList.Add(emails);
                    multiplemail = false;
                }
            }
            return emailList;
        }
        //Converts a list of userID to string of emails
        public string ConvertToMailFM(List<int> userIDList)
        {
            string emailList = null;
            UserDAO dao = new UserDAO();
            if (userIDList != null)
            {
                foreach (int ID in userIDList)
                {
                    emailList = emailList + dao.GetUserByID(ID).Email + ", ";
                }
                emailList = emailList.Substring(0, emailList.Length - 2);
            }
            return emailList;
        }

        //Sends email with username and password to user if the first and last name provided matches credentials
        public bool ForgotPass(UserFM fm)
        {
            UserDAO dao = new UserDAO();
            User user = dao.GetUserByEmail(fm.Email);
            if (fm.FirstName == user.FirstName && fm.LastName == user.LastName)
            {
                SendPass(user);
                return true;
            }
            NotifyUser(user);
            return false;
        }
        //Insert To and From
        public MailFM ToFrom(string email)
        {
            MailFM mail = new MailFM();
            mail.To = email;
            mail.From = "mycheerbook@gmail.com";
            return mail;
        }
        //Constructs Message for Password Reset
        public void SendPass(User user)
        {
            MailFM mail = ToFrom(user.Email);
            mail.Subject = "MyCheerBook";
            mail.Body = "<p>" + user.FirstName + " " + user.LastName + ",</p><p>UserName: " + user.Email + "<br/>Password: " + user.Password + "</p><p>MyCheerBook Team</p>";
            SendMail(mail);
        }
        //Notifies user that someone tried to get thier password
        public void NotifyUser(User user)
        {
            MailFM mail = ToFrom(user.Email);
            mail.Subject = "MyCheerBook";
            mail.Body = "<p>" + user.FirstName + " " + user.LastName + ",</p><p>Someone tired to reset your password, but was unsessful.  If this was you, try using</br>First Name: " + user.FirstName + "</br>Last Name: " + user.LastName + "</p><p>MyCheerBook Team</p>";
            SendMail(mail);
        }

        //Request to join team(emailed to team address)
        public void TeamRequest(int userID, int teamID)
        {
            UserDAO dao = new UserDAO();
            TeamDAO tdao = new TeamDAO();
            MailFM fm = ToFrom(tdao.GetTeamByID(teamID).Email);
            fm.Subject = "Team Request - MyCheerBook";
            fm.Body = TeamRequestBody(dao.GetUserByID(userID), dao.GetUserByID(tdao.GetTeamByID(teamID).ID));
            SendMail(fm);
        }
        //Constructs Message for Team Request
        public string TeamRequestBody(User user, User coach)
        {
            return ("<p>" + coach.FirstName + " " + coach.LastName + ",</p></br><p>" + user.FirstName + " " + user.LastName + ", requeset to join your team.  If you would like them to join your team, please log into MyCheerBook and add them.</p><br/><p>MyCheerBook Team</p>");
        }
    }
}