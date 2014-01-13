using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
    public class StatusFM
    {
        public int UserID { get; set; }

        [Display(Name = "Current Status:")]
        public string Message { get; set; }
    }
}