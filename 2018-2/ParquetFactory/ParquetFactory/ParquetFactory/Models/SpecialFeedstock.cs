using System;

namespace ParquetFactory.Models
{
    public class SpecialFeedstock : Feedstock
    {
        private int relativeHumidity;

        public int RelativeHumidity
        {
            get => relativeHumidity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The relative humidity of the feedstock cannot be a negative number.");
                }

                relativeHumidity = value;
            }
        }
        
        public SpecialFeedstock(string code, string name, double quantity, int durability, string dateOfEntry, string location, int relativeHumidity) 
            : base(code, name, quantity, durability, dateOfEntry, location)
        {
            this.FeedstockType = FeedstockType.E;
            this.RelativeHumidity = relativeHumidity;
        }
        
        public override string ToString()
        {
            return base.ToString() + $", B%={relativeHumidity}";
        }
    }
}