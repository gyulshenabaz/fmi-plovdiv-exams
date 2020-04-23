using System;

namespace ParquetFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine(new FeedstockManager());
            engine.Run();
        }
    }
}