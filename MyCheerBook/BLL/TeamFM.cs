using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
    public class TeamFM
    {
        [Required]
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }

        [Display(Name = "Coach Name")]
        public string Coach { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Team or Coach's Email")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Display(Name = "Address Line 1")]
        public string Line1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string Line2 { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public int Zip { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "Website Address")]
        public string Web { get; set; }
    }
}
