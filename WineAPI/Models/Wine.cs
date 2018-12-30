using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WineAPI.Models
{
    public class Wine
    {
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public int Year { get; set; }

        public DateTime PurchasedOn{ get; set; }
    }
}
