using System;

namespace ParquetFactory.Models
{
    public class NormalFeedstock : Feedstock
    {
        public NormalFeedstock(string code, string name, double quantity, int durability, string dateOfEntry, string location)
            : base(code, name, quantity, durability, dateOfEntry, location)
        {
            this.FeedstockType = FeedstockType.S;
        }
    }
}