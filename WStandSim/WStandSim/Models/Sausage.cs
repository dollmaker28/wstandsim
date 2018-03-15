using System;
using System.Collections.Generic;
using System.Text;

namespace WStandSim.Models
{
    public class Sausage : Item
    {
        int dueDays;
        public Sausage(string itemName) : base (itemName)
        {
            this.itemName = itemName;
            this.dueDays = 15;
        }
    }
}
