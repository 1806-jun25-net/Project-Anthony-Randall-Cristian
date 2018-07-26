using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ZVRPub.MVCFrontEnd.Models
{
    public class InventoryHasLocation
    {

        public int Id { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]
        public int InventoryId { get; set; }
        [Required]
        public int Quantity { get; set; }
        

    }
}
