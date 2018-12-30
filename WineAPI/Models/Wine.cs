using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WineAPI.Models
{
    public class Wine
    {
        [Required(ErrorMessage = "A wine must have a name")]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Required(ErrorMessage = "A wine must have an amount")]
        [Range(0, 99, ErrorMessage = "Geef een aantal tussen 0 en 99 in.")]
        public int Amount { get; set; }

        public int Year { get; set; } = 1900;
 
        public DateTime PurchasedOn { get; set; }

        public Chateau Chateau { get; set; }
    }
}
