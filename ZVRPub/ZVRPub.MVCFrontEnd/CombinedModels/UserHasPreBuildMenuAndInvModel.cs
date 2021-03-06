﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZVRPub.API.ModelsNeeded
{
    public class UserHasPreBuildMenuAndInvModel
    {
        public IEnumerable<OrderModel> Order { get; set; }
        public string User { get; set; }
        public IEnumerable<MenuPreBuiltModel> PreBuilt { get; set; }
        //public ICollection<MenuPreBuiltHasInventoryModel> PreBuiltHasInv { get; set; }
        public IEnumerable<MenuPrebuiltHasOrdersModel> PreBuiltHasOrder { get; set; }
        public IEnumerable<InventoryModel> Inventories { get; set; }
        public IEnumerable<LocationModel> Location { get; set; }
    }
}
