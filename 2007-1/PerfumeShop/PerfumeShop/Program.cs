using System;
using System.Collections.Generic;
using System.Linq;

namespace PerfumeShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine(new ClientManager());
            engine.Run();
        }
    }
}