using System;
using System.Collections.Generic;
using System.Text;

namespace WStandSim.Models
{
    public class Lemonade : Item
    {
        int dueDays;
        public Lemonade(string itemName) : base(itemName)
        {
            this.itemName = itemName;
            this.dueDays = 25;
        }
    }
}