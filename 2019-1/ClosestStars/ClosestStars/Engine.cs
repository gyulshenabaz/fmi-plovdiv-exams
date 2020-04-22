using System;
using System.Linq;

namespace ClosestStars
{
    public class Engine
    {
        private StarsManager starsManager;

        public Engine(StarsManager starsManager)
        {
            this.starsManager = starsManager;
        }
        
        public void Run()
        {
            int n = 0;
            
            while (n<1 || n>2000)
            {
                Console.Write("Enter number of clients n [1-2000]: ");
                n = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                var arguments = Console.ReadLine()
                    .Split(", ")
                    .ToList();

                var result = starsManager.AddStar(arguments);

                if (result != null)
                {
                    Console.WriteLine(result);
                }
            }
            
            Console.WriteLine(starsManager.GetAllStars());
            Console.WriteLine(starsManager.GetAverageMassForAllConstellations());
        }
    }
}