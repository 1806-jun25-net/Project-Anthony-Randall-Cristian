using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZVRPub.MVCFrontEnd.Models
{
    public class Inventory
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "Ingredient Name")]
        public string IngredientName { get; set; }
        [Required]
        [Display(Name = "Ingredient Type")]
        public string IngredientType { get; set; }
        [Required]
        [Display(Name = "Ingredient Price")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal Price { get; set; }

    }
}
