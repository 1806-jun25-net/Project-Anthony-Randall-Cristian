using System;
using System.Collections.Generic;
using System.Text;

namespace ZVRPub.Library.Interfaces
{
    interface IOrder
    {
         int OrderId { get; set; }
         DateTime OrderTime { get; set; }
         int LocationId { get; set; }
         int UserId { get; set; }

         
    }
}
