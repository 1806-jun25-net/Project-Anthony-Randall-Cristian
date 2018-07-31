using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZVRPub.MVCFrontEnd.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderTime { get; set; }
        [Required]
        public string Location { get; set; }
        
        public string  Username { get; set; }

    }
}
