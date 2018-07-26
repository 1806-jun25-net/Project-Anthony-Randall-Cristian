using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZVRPub.MVCFrontEnd.Models
{
    public class MenuCustomHasIventory
    {

        public int Id { get; set; }
        [Required]
        public int IdInventory { get; set; }
        [Required]
        public int IdMenuCustom { get; set; }

        


    }
}
