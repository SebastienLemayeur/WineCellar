using System.ComponentModel.DataAnnotations;

namespace WineLib.Models
{
    public class Producer : EntityBase
    {
        [Required(ErrorMessage = "A producer must have a name")]
        [StringLength(100, ErrorMessage = "The name cannot exceed 100 characters")]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "The country cannot exceed 100 characters")]
        public string Country { get; set; }

        [StringLength(100, ErrorMessage = "The region cannot exceed 100 characters")]
        public string Region { get; set; }
    }
}
