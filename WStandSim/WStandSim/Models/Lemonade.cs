﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WStandSim.Models
{
    public class Lemonade : Item
    {
        new string itemName;
        int dueDays;
        public Lemonade(string itemName) : base(itemName)
        {
            this.itemName = itemName;
            this.dueDays = 25;
        }
    }
}