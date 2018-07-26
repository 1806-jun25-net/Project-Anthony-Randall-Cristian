using System;
using System.Collections.Generic;
using System.Text;

namespace ZVRPub.Library.Interfaces
{
    interface ILocation
    {
         int Id { get; set; }
         string StreetAddress { get; set; }
         string PostalCode { get; set; }
         string City { get; set; }
         string States { get; set; }
    }
}
