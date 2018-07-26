using System;
using System.Collections.Generic;
using System.Text;
using ZVRPub.Library.Interfaces;

namespace ZVRPub.Library.Model
{
    class Inventory : IInventory

    {
        public int Id { get ; set ; }
        public string IngredientName { get ; set ; }
        public string IngredientType { get; set ; }
        public decimal Price { get ; set ; }
    }
}
