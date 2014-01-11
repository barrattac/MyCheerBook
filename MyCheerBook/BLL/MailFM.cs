﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
    public class MailFM
    {
        [Display(Name = "From:")]
        public string From { get; set; }

        [Display(Name = "To:")]
        public string To { get; set; }

        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Display(Name = "Body")]
        public string Body { get; set; }
    }
}