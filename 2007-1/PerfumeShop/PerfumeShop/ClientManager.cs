using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfumeShop
{
    public class ClientManager
    {
        private List<Client> clients;

        public ClientManager()
        {
            clients = new List<Client>();
        }
        
        public string RegisterClient(List<string> arguments)
        {
            string name = arguments[0];
            string town = arguments[1];
            string promoCode = arguments[2];

            try
            {
                clients.Add(new Client(name,town, promoCode));
            }
            catch (ArgumentException e)
            {
                return $"Client is not registered. {e.Message}";
            }

            return null;
        }

        public string GetAllClients()
        {
            StringBuilder sb = new StringBuilder();

            var allClients = clients.OrderBy(c => c.Name);

            if (!allClients.Any())
            {
                sb.AppendLine("No clients added.");
            }
            
            foreach (var client in allClients)
            {
                sb.AppendLine(client.ToString());
            }

            return sb.ToString().Trim();
        }

        public string GetAllClientsFromPlovdivWithCosmeticsPromo()
        {
            StringBuilder sb = new StringBuilder();

            var clientsFromPlovdivWithCosmeticsPromo = clients
                .Where(c => c.Town == "Пловдив" && c.CategoryNumber == "1")
                .OrderBy(c => c.DiscountPercent)
                .ThenByDescending(c => c.Name);

            if (!clientsFromPlovdivWithCosmeticsPromo.Any())
            {
                sb.AppendLine("No clients found.");
            }

            foreach (var client in clientsFromPlovdivWithCosmeticsPromo)
            {
                sb.AppendLine(client.ToString());
            }

            return sb.ToString().Trim();
        }
        
        public string GetMaxPercentageOfDiscountForCategory(string categoryNumber)
        {
            var category = GetCategoryFromNumber(categoryNumber);

            if (category == null)
            {
                return $"Category with number {categoryNumber} doesn't exist.";
            }

            var clientsInCategory = clients
                .Where(c => c.CategoryNumber == categoryNumber);

            if (!clientsInCategory.Any())
            {
                return $"No customers in this category.";
            }
            
            var maxPercentage = clientsInCategory
                .Max(c => c.DiscountPercent);

            return $"Max percentage of discount in category {category} is {maxPercentage}.";
        }

        public string GetCategoryFromNumber(string categoryNumber)
        {
            string category = null;
            
            switch (categoryNumber)
            {
                case "1":
                    category = "козметика";
                    break;
                case "2":
                    category = "парфюми";
                    break;
                case "3":
                    category = "аксесоари";
                    break; 
                case "4":
                    category = "услуги";
                    break;
            } 
            
            return category;
        }

        public string GetAllPromoCategories()
        {
            StringBuilder sb = new StringBuilder();

            var allCategories = new List<string> {"козметика", "парфюми", "аксесоари", "услуги"};

            sb.AppendLine("All categories: ");

            for (int i = 0; i < allCategories.Count; i++)
            {
                sb.AppendLine($"{i+1}. {allCategories[i]}");
            }

            return sb.ToString().Trim();
        }
    }
}
