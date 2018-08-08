using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZVRPub.API.ModelsNeeded;

namespace ZVRPub.MVCFrontEnd.Models
{
    public class UserHasPremadeBurgerAndItemModel
    {
        public IEnumerable<OrderModel> Order { get; set; }
        public string User { get; set; }
        public IEnumerable<MenuPreBuiltModel> PreBuilt { get; set; }
        //public ICollection<MenuPreBuiltHasInventory> PreBuiltHasInv { get; set; }
        public IEnumerable<MenuPrebuiltHasOrdersModel> PreBuiltHasOrder { get; set; }
        public IEnumerable<InventoryModel> Inventories { get; set; }
        public IEnumerable<LocationModel> Location { get; set; }
        public decimal[] Price { get; set; }

    }
}
