using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WineLib.Models
{
    public class Wine : EntityBase
    {
        [Required(ErrorMessage = "A wine must have a name")]
        [StringLength(100, ErrorMessage = "The name cannot exceed 100 characters")]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Required(ErrorMessage = "A wine must have an amount")]
        [Range(0, 99, ErrorMessage = "Geef een aantal tussen 0 en 99 in.")]
        public int Amount { get; set; }

        public int Year { get; set; } = 1900;

        public int DrinkBefore { get; set; }

        public DateTime PurchasedOn { get; set; }

        public int TypeId { get; set; }
        public WineType Type{ get; set; }

        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
    }
}
