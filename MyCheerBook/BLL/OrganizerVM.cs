﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class OrganizerVM
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public int Contact { get; set; }
    }
}
