using System;
using System.Collections.Generic;
using System.Text;
using ZVRPub.Library.Interfaces;

namespace ZVRPub.Library.Model
{
    class Location : ILocation
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string States { get; set; }
    }
}
