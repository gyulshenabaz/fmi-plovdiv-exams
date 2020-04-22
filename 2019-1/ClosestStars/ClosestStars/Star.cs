using System;

namespace ClosestStars
{
    public class Star
    {
        private string name;
        private double distance;
        private int classificationNumber;
        private string constellation;
        private double mass;
        
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 20)
                {
                    throw new ArgumentException("The name of the star should be between 1 and 20 symbols.");
                }

                name = value;
            }
        }

        public double Distance
        {
            get => distance;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The distance to the star should be bigger than 0.");
                }

                distance = value;
            }
        }

        public int ClassificationNumber
        {
            get => classificationNumber;
            private set
            {
                if (value <=0 || value > 9)
                {
                    throw new ArgumentException("Classification of the star should be a number between 1 and 9");
                }

                classificationNumber = value;
            }
        }
        
        public double Mass
        {
            get => mass;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The mass of the star should be bigger than 0.");
                }

                mass = value;
            }
        }
        
        public string Constellation
        {
            get => constellation;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 30)
                {
                    throw new ArgumentException("The name of the constellation should be a number between 1 and 30 symbols");
                }

                constellation = value;
            }
        }

        public string Classication => GetClassification();
        
        public Star(string name, double distance, int classification, double mass, string constellation)
        {
            this.Name = name;
            this.Distance = distance;
            this.ClassificationNumber = classification;
            this.Mass = mass;
            this.Constellation = constellation;
        }

        public override string ToString()
        {
            return $"{Name}, {Distance} св.г, {Classication}, {Mass} сл.м, {Constellation}";
        }

        private string GetClassification()
        {
            string classication = null;
            
            switch (this.classificationNumber)
            {
                case 1:
                    classication = "хипергигант";
                    break;
                case 2:
                    classication = "свръхгигант";
                    break;
                case 3:
                    classication = "ярък гигант";
                    break;
                case 4:
                    classication = "гигант";
                    break;
                case 5:
                    classication = "субгигант";
                    break;
                case 6:
                    classication = "джудже";
                    break;
                case 7:
                    classication = "субджудже";
                    break;
                case 8:
                    classication = "червено джудже";
                    break;
                case 9:
                    classication = "кафяво джудже";
                    break;
            }

            return classication;
        }
    }
}