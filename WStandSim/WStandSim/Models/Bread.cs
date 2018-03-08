﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WStandSim.Models
{
    public class Bread : Item
    {
        new string itemName;
        int dueDays;
        public Bread(string itemName) : base(itemName)
        {
            this.itemName = itemName;
            this.dueDays = 5;
        }
    }
}