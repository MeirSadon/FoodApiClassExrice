﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodExrice_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GetterAndPoster gap = new GetterAndPoster();
            //gap.AddFood();
            gap.ReadAllFood();
        }
    }
}
