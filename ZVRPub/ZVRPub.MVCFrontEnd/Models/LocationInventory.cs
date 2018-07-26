using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZVRPub.MVCFrontEnd.Models
{
    public class LocationInventory
    {
        public int Id { get; set; }

        [Required]
        public string IngredientName { get; set; }

        [Required]
        public string IngredientType { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
