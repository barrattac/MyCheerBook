using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class OrganizerServices
    {
        //Checks to see if organization already exist(compares emails)
        public bool IsExistingOrganization(string email)
        {
            OrganizerDAO dao = new OrganizerDAO();
            foreach (Organizers organizer in dao.GetAllOrganizers())
            {
                if (organizer.Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        //Adds organization to db
        public void CreateOrganization(OrganizerFM fm)
        {
            ContactDAO cdao = new ContactDAO();
            OrganizerDAO dao = new OrganizerDAO();
            cdao.AddContactInfo(ConvertContact(fm.Contact));
            dao.AddOrganization(ConvertOrganization(fm));
        }

        //Converts fm to an organization
        public Organizers ConvertOrganization(OrganizerFM fm)
        {
            Organizers organizer = new Organizers();
            ContactDAO dao = new ContactDAO();
            organizer.CompanyName = fm.CompanyName;
            organizer.Email = fm.Email;
            organizer.Password = fm.Password;
            organizer.Contact = dao.GetContact(ConvertContact(fm.Contact));
            return organizer;
        }

        //Converts a fm into contact info
        public ContactInfo ConvertContact(ContactFM contactFM)
        {
            ContactInfo info = new ContactInfo();
            info.Phone = contactFM.Phone;
            info.Line1 = contactFM.Line1;
            info.Line2 = contactFM.Line2;
            info.City = contactFM.City;
            info.State = contactFM.State;
            info.Zip = contactFM.Zip;
            info.Website = contactFM.Website;
            return info;
        }

        //Get organization by their email address
        public Organizers GetOrganizerByEmail(string email)
        {
            OrganizerDAO dao = new OrganizerDAO();
            return dao.GetOrganizationByEmail(email);
        }
    }
}
