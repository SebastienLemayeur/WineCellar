using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WineAPI.Models
{
    public class Chateau
    {
        [Required(ErrorMessage = "A chateau must have a name")]
        public string Name { get; set; }

        public string Country { get; set; }

        public string Region { get; set; }
    }
}
