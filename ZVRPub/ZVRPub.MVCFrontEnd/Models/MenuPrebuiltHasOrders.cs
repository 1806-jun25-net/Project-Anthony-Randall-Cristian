using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZVRPub.MVCFrontEnd.Models
{
    public class MenuPrebuiltHasOrders
    {

        public int Id { get; set; }
        [Required]
        public int MenuPreBuildId { get; set; }
        [Required]
        public int OrdersId { get; set; }

    }
}
