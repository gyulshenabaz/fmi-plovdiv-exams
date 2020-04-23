using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParquetFactory.Models;

namespace ParquetFactory
{
    public class FeedstockManager
    {
        private List<Feedstock> feedstocks;

        private FeedstockFactory feedstockFactory;

        public FeedstockManager()
        {
            feedstocks = new List<Feedstock>();
            this.feedstockFactory = new FeedstockFactory();
        }

        public string AddFeedstock(List<string> arguments)
        {
            try
            {
                var feedstock = feedstockFactory.GetFeedstock(arguments);

                if (feedstock == null)
                {
                    return $"Feedstock is not added.";
                }
                
                feedstocks.Add(feedstock);
            }
            catch (ArgumentException e)
            {
                return $"Feedstock is not added. {e.Message}";
            }

            return null;
        }

        public string GetAllFeedstocks()
        {
            StringBuilder sb = new StringBuilder();

            var allFeedstocks = feedstocks
                .OrderBy(f => f.Location)
                .ToList();

            if (!allFeedstocks.Any())
            {
                sb.AppendLine("No feedstocks added.");
            }
            else
            {
                sb.AppendLine("All feedstocks: ");
                
                foreach (var feedstock in allFeedstocks)
                {
                    sb.AppendLine(feedstock.ToString());
                }
            }

            return sb.ToString().Trim();
        }

        public string GetAllSpecialFeedstocks()
        {
            StringBuilder sb = new StringBuilder();

            var allSpecialFeedstocks = feedstocks
                .Where(f=>f.FeedstockType == FeedstockType.E)
                .OrderBy(f => f.DateOfEntry)
                .ThenByDescending(f=>f.Durability)
                .ToList();

            if (!allSpecialFeedstocks.Any())
            {
                sb.AppendLine("No special feedstocks added.");
            }
            else
            {
                sb.AppendLine("All special feedstocks: ");
                
                foreach (var feedstock in allSpecialFeedstocks)
                {
                    sb.AppendLine(feedstock.ToString());
                }
            }

            return sb.ToString().Trim();
        }
        
        public string GetAllFeedstocksWithCode(string code)
        {
            StringBuilder sb = new StringBuilder();

            var feedstocksWithCode = feedstocks
                .Where(f=>f.Code == code)
                .ToList();

            if (!feedstocksWithCode.Any())
            {
                sb.AppendLine($"No feedstocks with code {code} added.");
            }
            else
            {
                sb.AppendLine($"All feedstocks with code {code}: ");
                
                foreach (var feedstock in feedstocksWithCode)
                {
                    sb.AppendLine(feedstock.ToString());
                }
            }
            
            double totalQuantity = feedstocksWithCode
                .Sum(f => f.Quantity);
            
            bool isSpecial = feedstocksWithCode
                .All(f => f.FeedstockType == FeedstockType.E);

            if (isSpecial)
            {
                int minRelativeHumidity = feedstocksWithCode
                    .Cast<SpecialFeedstock>()
                    .Min(s => s.RelativeHumidity);
                
                sb.AppendLine($"Minimum relative humidity for storing: {minRelativeHumidity}.");
            }

            sb.AppendLine($"Total quantity in factory: {totalQuantity}.");
            
            return sb.ToString().Trim();
        }
    }
}