﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_GreetingConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramUI ui = new ProgramUI();
            ui.Run();
            Console.ReadKey();
        }
    }
}
