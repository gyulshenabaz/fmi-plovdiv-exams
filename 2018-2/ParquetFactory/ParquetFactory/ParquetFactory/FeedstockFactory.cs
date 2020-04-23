using System.Collections.Generic;
using ParquetFactory.Models;

namespace ParquetFactory
{
    public class FeedstockFactory
    {
        public Feedstock GetFeedstock(List<string> arguments)
        {
            var type = arguments[4];

            Feedstock feedstock = null;
            
            switch (type)
            {
                case "S":
                    feedstock = new NormalFeedstock(arguments[0], arguments[1], double.Parse(arguments[2]), 
                        int.Parse(arguments[3]), arguments[5], arguments[6]);
                    break;
                case "E":
                    feedstock = new SpecialFeedstock(arguments[0], arguments[1], double.Parse(arguments[2]), 
                        int.Parse(arguments[3]), arguments[5], arguments[6], int.Parse(arguments[7]));
                    break;
            }
            
            return feedstock;
        }
    }
}