using System;
using System.Collections.Generic;
using System.Text;

namespace ZVRPub.Library.Interfaces
{
    interface IMenuCustom
    {
         int Id { get; set; }
         string NameOfCustomMenu { get; set; }
         int IdOrders { get; set; }
    }
}
