using System;

namespace ClosestStars
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine(new StarsManager());
            engine.Run();
        }
    }
}