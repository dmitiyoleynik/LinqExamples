﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplesLinq
{
    class User
    {
        public string Name { get; set; }
        
        public int Age { get; set; }

        public string Hobby { get; set; }

        public string Language { get; set; }

        public void Print()
        {
            Console.WriteLine($"User {Name}, age {Age}, hobby {Hobby}, language {Language}");
        }

    }
}
