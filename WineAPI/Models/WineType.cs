using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WineAPI.Models
{
    public class WineType : EntityBase
    {
        [Required(ErrorMessage = "A type must have a name")]
        [StringLength(50, ErrorMessage = "The type cannot exceed 50 characters")]
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
