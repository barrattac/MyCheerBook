using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Teams
    {
        public int ID { get; set; }
        public string TeamName { get; set; }
        public string Coach { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Web { get; set; }
    }
}
