using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplesLinq
{
    class Phone
    {
        public string Model { get; set; }

        public int Price { get; set; }

        public void Print()
        {
            Console.WriteLine($"Model {Model}, Price {Price}");
        }

    }
}
