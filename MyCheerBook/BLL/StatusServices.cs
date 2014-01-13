using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class StatusServices
    {
        //Updates a user's status
        public void AddStatus(StatusFM fm)
        {
            StatusDAO dao = new StatusDAO();
            Status status = new Status();
            status.UserID = fm.UserID;
            status.Message = fm.Message;
            status.Date = DateTime.Now;
            dao.AddStatus(status);
        }
    }
}
