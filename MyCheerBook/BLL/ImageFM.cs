using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
    public class ImageFM
    {
        [Required]
        [Display(Name = "Add Image")]
        public string Image { get; set; }
    }
}
