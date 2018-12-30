using System.ComponentModel.DataAnnotations;

namespace WineAPI.Models
{
    public class Producer
    {
        [Required(ErrorMessage = "A producer must have a name")]
        public string Name { get; set; }

        public string Country { get; set; }

        public string Region { get; set; }
    }
}
