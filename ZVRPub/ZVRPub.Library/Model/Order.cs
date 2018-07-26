using System;
using System.Collections.Generic;
using System.Text;
using ZVRPub.Library.Interfaces;

namespace ZVRPub.Library.Model
{
    class Order : IOrder
    {
        public int OrderId { get; set ; }
        public DateTime OrderTime { get ; set ; }
        public int LocationId { get ; set ; }
        public int UserId { get ; set ; }
    }
}
