using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop
{
    public class CustomersManager
    {
        private List<Customer> customers;

        public CustomersManager()
        {
            this.customers = new List<Customer>();
        }

        public string RegisterCustomer(List<string> arguments)
        {
            string name = arguments[0];
            string dateOfRegistration = arguments[1];
            int numberOfPurchases = int.Parse(arguments[2]);
            double totalSumOfPurchases = double.Parse(arguments[3]);

            try
            {
                customers.Add(new Customer(name, dateOfRegistration, numberOfPurchases, totalSumOfPurchases));
            }
            catch (ArgumentException e)
            {
                return $"Customer is not added. {e.Message}";
            }

            return null;
        }
        
        public string GetAllCustomers()
        {
            StringBuilder sb = new StringBuilder();

            var allCustomers = customers
                .OrderBy(c => c.Name)
                .ToList();

            if (!allCustomers.Any())
            {
                sb.AppendLine("No customers added.");
            }
            else
            {
                sb.AppendLine("All customers: ");

                foreach (var customer in allCustomers)
                {
                    sb.AppendLine(customer.ToString());
                }
            }

            return sb.ToString().Trim();
        }

        public string GetAllCustomersWithTwoRatings()
        {
            StringBuilder sb = new StringBuilder();
            
            var customersWithTwoRatings = customers
                .Where(c => c.Rating == 2)
                .OrderByDescending(c => c.TotalSumOfPurchases)
                .ThenBy(c => c.Name)
                .ToList();

            if (!customersWithTwoRatings.Any())
            {
                sb.AppendLine("There aren't any customers with rating that is equal to 2.");
            }
            else
            {
                sb.AppendLine("Customers with ratings equal to 2: ");
                
                foreach (var customer in customersWithTwoRatings)
                {
                    sb.AppendLine(customer.ToString());
                }
            }

            return sb.ToString().Trim();
        }

        public string GetAllClientsInYearsWithRating(int rating)
        {
            if (rating < 1 || rating > 5)
            {
                return $"Invalid rating.";
            }

            StringBuilder sb = new StringBuilder();
            
            var customersWithRating = customers
                .Where(c => c.Rating == rating)
                .GroupBy(c => c.RegistrationDate.Substring(6))
                .OrderBy(c=>c.Key)
                .ToList();

            if (!customersWithRating.Any())
            {
                sb.AppendLine("There aren't any customers.");
            }
            else
            {
                sb.AppendLine($"All customers in every year with rating {rating}: ");

                foreach (var customer in customersWithRating)
                {
                    sb.AppendLine($"{customer.Key} - {customer.Count()}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}