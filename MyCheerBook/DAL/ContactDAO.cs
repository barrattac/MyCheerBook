using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class ContactDAO
    {
        //Writes to database
        public void Write(string statement, SqlParameter[] parameters)
        {
            UserDAO userDao = new UserDAO();
            userDao.Write(statement, parameters);
        }

        //Reads from database for contact info
        public List<ContactInfo> ReadContactInfo(string statement, SqlParameter[] parameters)
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
                    List<ContactInfo> contacts = new List<ContactInfo>();
                    while (data.Read())
                    {
                        ContactInfo contact = new ContactInfo();
                        contact.ID = Convert.ToInt32(data["ID"]);
                        contact.Phone = data["Phone"].ToString();
                        contact.Line1 = data["Line1"].ToString();
                        contact.Line2 = data["Line2"].ToString();
                        contact.City = data["City"].ToString();
                        contact.State = data["State"].ToString();
                        contact.Zip = Convert.ToInt32(data["Zip"]);
                        contact.Website = data["Web"].ToString();
                        contacts.Add(contact);
                    }
                    try
                    {
                        return contacts;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }

        public int GetContact(ContactInfo contactInfo)
        {
            throw new NotImplementedException();
        }

        public void AddContactInfo(ContactInfo contactInfo)
        {
            throw new NotImplementedException();
        }
    }
}
