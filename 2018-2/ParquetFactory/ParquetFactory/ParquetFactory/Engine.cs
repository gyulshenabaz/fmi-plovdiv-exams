using System;
using System.Linq;

namespace ParquetFactory
{
    public class Engine
    {
        private FeedstockManager feedstockManager;

        public Engine(FeedstockManager feedstockManager)
        {
            this.feedstockManager = feedstockManager;
        }
        
        public void Run()
        {
            int n = 0;
            
            while (n<1 || n>10000)
            {
                Console.Write("Enter number of feedstcoks [1-10000]: ");
                n = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                var arguments = Console.ReadLine()
                    .Split(", ")
                    .ToList();

                var result = feedstockManager.AddFeedstock(arguments);

                if (result != null)
                {
                    Console.WriteLine(result);
                }
            }
            
            Console.WriteLine(feedstockManager.GetAllFeedstocks());
            Console.WriteLine(feedstockManager.GetAllSpecialFeedstocks());
            
            Console.Write("Enter code: ");
            string code = Console.ReadLine();
            
            Console.WriteLine(feedstockManager.GetAllFeedstocksWithCode(code));
        }
    }
}