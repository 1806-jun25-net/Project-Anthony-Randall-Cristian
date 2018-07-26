using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZVRPub.MVCFrontEnd.Models
{
    public class LocationOrderProcess
    {

        public int Id { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]
        public int OrderId { get; set; }

        

    }
}
