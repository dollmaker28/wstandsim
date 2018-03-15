using System;
using System.Collections.Generic;
using System.Text;

namespace WStandSim.Models
{
    public class Beer : Item
    {
        int dueDays;
        public Beer(string itemName) : base(itemName)
        {
            this.itemName = itemName;
            this.dueDays = 25;
        }
    }
}