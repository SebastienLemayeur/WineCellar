using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WineAPI.Models
{
    public class WineType
    {
        [Required(ErrorMessage = "A type must have a name")]
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
