using System;
using System.Runtime.CompilerServices;

namespace PerfumeShop
{
    public class Client
    {
        private string name;
        private string town;
        private string promoCode;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 30)
                {
                    throw new ArgumentException("The name of the client should be between 1 and 30 symbols.");
                }
                
                name = value;
            }
        }
        
        public string Town
        {
            get => town;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 10)
                {
                    throw new ArgumentException("The town of should be between 1 and 10 symbols.");
                }
                
                town = value;
            }
        }
        
        public string PromoCode
        {
            get => promoCode;
            private set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentException("The promo code should consist of 10 numbers.");
                }
                
                promoCode = value;
            }
        }

        public string CategoryNumber => GetCategoryNumber();
        
        public string CategoryType => GetCategoryType();

        public string AccumulationDiscount => GetAccumulationDiscount();

        public int DiscountPercent => GetDiscountPercent();
        
        public string PromoDay => GetPromoDay();
        
        public string PromoMonth => GetPromoMonth();
        
        public string PromoYear => GetPromoYear();

        public Client(string name, string town, string promoCode)
        {
            this.Name = name;
            this.Town = town;
            this.PromoCode = promoCode;
        }

        public override string ToString()
        {
            return $"{this.Name}, {this.Town}, {this.CategoryType}, {this.AccumulationDiscount}," +
                   $" {this.DiscountPercent}, {this.PromoDay}.{this.PromoMonth}.{this.PromoYear}";
        }

        private string GetCategoryNumber()
        {
            return this.promoCode[0].ToString();
        }
        
        private string GetCategoryType()
        {
            var categoryNumber = this.promoCode[0];

            string category = string.Empty;
            
            switch (categoryNumber)
            {
                case '1':
                    category = "козметика";
                    break;
                case '2':
                    category = "парфюми";
                    break;
                case '3':
                    category = "аксесоари";
                    break; 
                case '4':
                    category = "услуги";
                    break;
            } 
            
            return category;
        }

        private string GetAccumulationDiscount()
        {
            var accumulation = this.promoCode[1];

            return accumulation == '0' ? "без натрупване" : "с натрупване";
        }
        
        private int GetDiscountPercent()
        {
            int discountPercent = int.Parse(promoCode.Substring(2, 2));

            return discountPercent;
        }
        
        private string GetPromoDay()
        {
            string promoDay = promoCode.Substring(4, 2);

            return promoDay;
        }
        
        private string GetPromoMonth()
        {
            string promoMonth = promoCode.Substring(6, 2);

            return promoMonth;
        }
        
        private string GetPromoYear()
        {
            string promoYear = promoCode.Substring(8, 2);

            return promoYear;
        }
    }
}
