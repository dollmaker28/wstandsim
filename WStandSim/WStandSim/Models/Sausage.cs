using System;
using System.Collections.Generic;
using System.Text;

namespace WStandSim.Models
{
    public class Sausage : Item
    {
        new string itemName;
        int dueDays;
        public Sausage(string itemName) : base (itemName)
        {
            this.itemName = itemName;
            this.dueDays = 15;
        }
    }
}
