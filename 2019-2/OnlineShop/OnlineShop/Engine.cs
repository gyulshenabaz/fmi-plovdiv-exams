using System;
using System.Linq;

namespace OnlineShop
{
    public class Engine
    {

        private CustomersManager customersManager;

        public Engine(CustomersManager customersManager)
        {
            this.customersManager = customersManager;
        }
        
        public void Run()
        {
            int n = 0;
            
            while (n<1 || n>5000)
            {
                Console.Write("Enter number of clients n [1-5000]: ");
                n = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                var arguments = Console.ReadLine()
                    .Split(", ")
                    .ToList();

                var result = customersManager.RegisterCustomer(arguments);

                if (result != null)
                {
                    Console.WriteLine(result);
                }
            }
            
            Console.WriteLine(customersManager.GetAllCustomers());
            Console.WriteLine(customersManager.GetAllCustomersWithTwoRatings());
            
            Console.Write("Enter rating: ");
            int rating = int.Parse(Console.ReadLine());
            
            Console.WriteLine(customersManager.GetAllClientsInYearsWithRating(rating));
        }
    }
}