using System.ComponentModel.DataAnnotations;

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
