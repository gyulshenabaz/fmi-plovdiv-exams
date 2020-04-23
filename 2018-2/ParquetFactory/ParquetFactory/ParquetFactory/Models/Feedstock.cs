using System;
using System.Globalization;

namespace ParquetFactory.Models
{
    public abstract class Feedstock
    {
        private string code;
        private string name;
        private double quantity;
        private int durability;
        private string dateOfEntry;
        private string location;

        public string Code
        {
            get => code;
            protected set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 4)
                {
                    throw new ArgumentException("The code of the feedstock should be between 1 and 4 symbols.");
                }

                code = value;
            }
        }
        
        public string Name
        {
            get => name;
            protected set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 55)
                {
                    throw new ArgumentException("The name of the feedstock should be between 1 and 55 symbols.");
                }

                name = value;
            }
        }

        public double Quantity
        {
            get => quantity;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The quantity of the feedstock in cubic meters cannot be a negative number.");
                }

                quantity = value;
            }
        }

        public int Durability
        {
            get => durability;
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The durability of the feedstock (in days) cannot be a negative number.");
                }

                durability = value;
            }
        }
        
        public FeedstockType FeedstockType { get; protected set; }

        public string DateOfEntry
        {
            get => dateOfEntry;
            protected set
            {
                try
                {
                    var result = DateTime.ParseExact(value, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    dateOfEntry = value;
                }
                catch (Exception e)
                {
                    throw new ArgumentException($"The date of entry {value} is invalid");
                }
            }
        }

        public string Location
        {
            get => location;
            protected set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 10)
                {
                    throw new ArgumentException("The location of the feedstock should be between 1 and 10 symbols.");
                }

                location = value;
            }
        }

        protected Feedstock(string code, string name, double quantity, int durability, string dateOfEntry, string location)
        {
            this.Code = code;
            this.Name = name;
            this.Quantity = quantity;
            this.Durability = durability;
            this.DateOfEntry = dateOfEntry;
            this.Location = location;
        }
        
        public override string ToString()
        {
            return $"{Location}, {Code}, {Name}, {Quantity:f2}, {DateOfEntry}, {Durability}";
        }
    }
}