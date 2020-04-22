using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClosestStars
{
    public class StarsManager
    {
        private List<Star> stars;

        public StarsManager()
        {
            stars = new List<Star>();
        }

        public string AddStar(List<string> arguments)
        {
            string name = arguments[0];
            double distance = double.Parse(arguments[1]);
            int classification = int.Parse(arguments[2]);
            double mass = double.Parse(arguments[3]);
            string constellation = arguments[4];
            
            try
            {
                stars.Add(new Star(name, distance, classification, mass, constellation));
            }
            catch (ArgumentException e)
            {
                return $"Star is not added. {e.Message}";
            }

            return null;
        }
        
        public string GetAllStars()
        {
            StringBuilder sb = new StringBuilder();

            var allStars = stars
                .OrderBy(s => s.Distance)
                .ToList();

            if (!allStars.Any())
            {
                sb.AppendLine("No stars added.");
            }
            else
            {
                sb.AppendLine("All starts: ");
                
                foreach (var star in allStars)
                {
                    sb.AppendLine(star.ToString());
                }
            }

            return sb.ToString().Trim();
        }

        public string GetAverageMassForAllConstellations()
        {
            StringBuilder sb = new StringBuilder();
            
            var constellations = stars
                .GroupBy(s => s.Constellation)
                .ToList();

            if (!constellations.Any())
            {
                sb.AppendLine("No constellations are found");
            }
            else
            {
                foreach (var constellation in constellations)
                {
                    sb.AppendLine($"Constellation: {constellation.Key}, Average Mass: {constellation.Average(s=>s.Mass)}");
                }
            }
            
            return sb.ToString().Trim();
        }
    }
}