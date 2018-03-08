using System;
using System.Collections.Generic;
using System.Text;

namespace WStandSim.Models
{
    public abstract class Item
    {
        protected string itemName;
        public Item(string itemName)
        {
            this.itemName = itemName;
        }
    }
}
