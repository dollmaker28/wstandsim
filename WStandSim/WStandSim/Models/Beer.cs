using System;
using System.Collections.Generic;
using System.Text;

namespace WStandSim.Models
{
    public class Beer : Item
    {
        new string itemName;
        int dueDays;
        public Beer(string itemName) : base(itemName)
        {
            this.itemName = itemName;
            this.dueDays = 25;
        }
    }
}