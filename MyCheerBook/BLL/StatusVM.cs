using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StatusVM
    {
        public int ID { get; set; }
        public int userID { get; set; }
        public string status { get; set; }
        public DateTime date { get; set; }
    }
}