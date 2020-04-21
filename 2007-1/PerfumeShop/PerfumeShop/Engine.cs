using System;
using System.Linq;
using System.Reflection;

namespace PerfumeShop
{
    public class Engine
    {
        private ClientManager clientManager;

        public Engine(ClientManager clientManager)
        {
            this.clientManager = clientManager;
        }
        
        public void Run()
        {
            int n = 0;
            
            while (n<1 || n>500)
            {
                Console.Write("Enter number of clients n [1-500]: ");
                n = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                var arguments = Console.ReadLine()
                    .Split(", ")
                    .ToList();

                var result = clientManager.RegisterClient(arguments);

                if (result != null)
                {
                    Console.WriteLine(result);
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var result = ProcessCommand(input);
                Console.WriteLine(result);
            }
        }

        public string ProcessCommand(string input)
        {
            var split = input.Split(" ");

            var command = split[0];
            var parameters = split.Skip(1).ToArray();

            string result;

            switch (command)
            {
                case "GetAllClients":
                    result = this.clientManager.GetAllClients();
                    break;
                case "GetAllCategories":
                    result = this.clientManager.GetAllPromoCategories();
                    break;
                case "GetCategoryByNumber":
                    var category = this.clientManager.GetCategoryFromNumber(parameters[0]);
                    result = category ?? $"No category with number {parameters[0]}.";
                    break;
                case "GetMaxDiscountPercent":
                    result = this.clientManager.GetMaxPercentageOfDiscountForCategory(parameters[0]);
                    break;
                case "GetAllClientsFromPlovdivWithCosmeticsPromo":
                    result = this.clientManager.GetAllClientsFromPlovdivWithCosmeticsPromo();
                    break;
                default:
                    result = "No such command exists";
                    break;
            }
            
            return result;
        }
    }
}