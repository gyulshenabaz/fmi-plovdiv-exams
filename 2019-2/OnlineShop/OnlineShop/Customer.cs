using System;
using System.Globalization;

namespace OnlineShop
{
    public class Customer
    {
        private string name;
        private string registrationDate;
        private int numberOfPurchases;
        private double totalSumOfPurchases;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 40)
                {
                    throw new ArgumentException("The name of the customer should be between 1 and 40 symbols.");
                }

                name = value;
            }
        }

        public string RegistrationDate
        {
            get => registrationDate;
            private set
            {
                try
                {
                    var result = DateTime.ParseExact(value, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    registrationDate = value;
                }
                catch (FormatException)
                {
                    throw new ArgumentException($"The registration date {value} is not in the correct format.");
                }
            }
        }

        public int NumberOfPurchases
        {
            get => numberOfPurchases;
            private set
            {
                if (value < 1 && value > 9999)
                { 
                    throw new ArgumentException("The number of purchases has to be between 1-9999.");
                }
                
                numberOfPurchases = value;
            }
        }

        public double TotalSumOfPurchases
        {
            get => totalSumOfPurchases;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The total of the purchases cannot be 0 or negative.");
                }
                
                totalSumOfPurchases = value;
            }
        }

        public int Rating => GetRating();

        public Customer(string name, string registrationDate, int numberOfPurchases, double totalSumOfPurchases)
        {
            this.Name = name;
            this.RegistrationDate = registrationDate;
            this.numberOfPurchases = numberOfPurchases;
            this.TotalSumOfPurchases = totalSumOfPurchases;
        }

        public override string ToString()
        {
            return $"{Name}, {NumberOfPurchases}, {TotalSumOfPurchases:f2}, {RegistrationDate}, {new string('*', Rating)}";
        }
        
        private int GetRating()
        {
            if (this.NumberOfPurchases >= 1 && this.numberOfPurchases <= 99)
            {
                return 1;
            }
            else if (this.numberOfPurchases >= 100 && this.numberOfPurchases <= 299)
            {
                return 2;
            }
            else if (this.numberOfPurchases >= 300 && this.numberOfPurchases <= 499)
            {
                return 3;
            }
            else if (this.numberOfPurchases >= 500 && this.numberOfPurchases <= 999)
            {
                return 4;
            }
            else
            {
                return 5;
            }
        }
    }
}