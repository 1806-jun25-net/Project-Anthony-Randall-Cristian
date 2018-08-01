using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZVRPub.MVCFrontEnd.Models
{
    public class MenuPrebuiltHasOrders
    {

        public string NameOfProduct { get; set; }
        public int OrderId { get; set; }

    }
}
