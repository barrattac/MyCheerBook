using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
    public class VideoFM
    {
        [DataType(DataType.Url)]
        [Display(Name = "URL")]
        public string Location { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }
    }
}