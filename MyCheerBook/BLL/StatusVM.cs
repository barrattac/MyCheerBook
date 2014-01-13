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
        public int UserID { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}