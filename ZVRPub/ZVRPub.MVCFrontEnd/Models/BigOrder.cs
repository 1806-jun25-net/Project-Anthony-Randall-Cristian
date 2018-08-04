using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZVRPub.MVCFrontEnd.Models
{
    public class BigOrder
    {

        public string user { get; set; }
        public string Location { get; set; }
        
        public DateTime OrderTime { get; set; }

        public bool wrap { get; set; }
        [Range(0, 10, ErrorMessage = "Value should be greater than or equal to 1 nor more than 10")]
        public int QuantityWrap { get; set; } 
        public bool burger { get; set; }
        [Range(0,10, ErrorMessage = "Value should be greater than or equal to 1 nor more than 10")]
        public int QuantityBurger { get; set; } 
        public bool Taco { get; set; }
        [Range(0, 10, ErrorMessage = "Value should be greater than or equal to 1 nor more than 10")]
        public int QuantityTaco { get; set; } 
        public bool Draft_Beer { get; set; }
        [Range(0, 10, ErrorMessage = "Value should be greater than or equal to 1 nor more than 10")]
        public int QuantityDraft_Beer { get; set; } 
        public bool CockTail { get; set; }
        [Range(0, 10, ErrorMessage = "Value should be greater than or equal to 1 nor more than 10")]
        public int QuantityCocktail { get; set; } 
        public string Custom_Burger { get; set; }
        [Range(0, 10, ErrorMessage = "Value should be greater than or equal to 1 nor more than 10")]
        public int QuantityOfBurger { get; set; } 
        public bool CustomBurgerYes { get; set; }
        
        public string ingredient { get; set; } 
      
        public string ingredient1 { get; set; } 
        
        public string ingredient2 { get; set; } 
     
        public string ingredient3 { get; set; }
        
        public string ingredient4 { get; set; } 
       

    }
}
