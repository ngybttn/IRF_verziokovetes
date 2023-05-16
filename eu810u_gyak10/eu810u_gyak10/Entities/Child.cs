﻿using eu810u_gyak10.Enum;
using PackMaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eu810u_gyak10.Entities
{
    public class Child
    {
        public string Name { get; set; }
        public Behaviour YearlyBehaviour { get; set; }
        public List<Gift> Gifts { get; set; }

        public bool CheckBehaviour(int value)
        {
            if (value >= 1 && value <= 5)
            {
                return true;
            }
            return false;
        }


    }
}
