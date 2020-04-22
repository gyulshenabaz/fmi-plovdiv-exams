using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine(new CustomersManager());
            engine.Run();
        }
    }
}