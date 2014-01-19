using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class EventFM
    {
        public string EventName { get; set; }
        public int Location { get; set; }
        public int Organizer { get; set; }
        public DateTime Registration { get; set; }
        public DateTime Competition { get; set; }
        public string Details { get; set; }
    }
}