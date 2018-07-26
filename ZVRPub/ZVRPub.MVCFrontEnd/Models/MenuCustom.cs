using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZVRPub.MVCFrontEnd.Models
{
    public class MenuCustom
    {


        public int Id { get; set; }
        [Required]
        public string NameOfCustomMenu { get; set; }
        [Required]
        public int IdOrders { get; set; }

        



    }
}
