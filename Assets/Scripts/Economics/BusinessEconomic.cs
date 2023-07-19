using System.Collections.Generic;
using UnityEngine;

namespace Economics
{
    public class BusinessData
    {
        public float Price;
        public float HourlyIncome;
        public ShopTypeEnum.ShopType TypeOfShop;
    }
    public static class BusinessEconomic
    {
        public static Dictionary<string, BusinessData> BusinessPrices;
        
        static BusinessEconomic()
        {
            BusinessPrices = new Dictionary<string, BusinessData>();
            BusinessPrices.Add("Shop", new BusinessData { Price = 5000.0f, HourlyIncome = 1000.0f, TypeOfShop = ShopTypeEnum.ShopType.Small });
            BusinessPrices.Add("Shop", new BusinessData { Price = 15000.0f, HourlyIncome = 2500.0f, TypeOfShop = ShopTypeEnum.ShopType.ChainOfStores });
            BusinessPrices.Add("Shop", new BusinessData { Price = 50000.0f, HourlyIncome = 7000.0f, TypeOfShop = ShopTypeEnum.ShopType.Big });
        }

        public static float GetBusinessPrice(string businessName)
        {
            if (BusinessPrices.ContainsKey(businessName))
            {
                return BusinessPrices[businessName].Price;
            }
            else
            {
                Debug.LogError("Цена для бизнеса " + businessName + " не найдена.");
                return 0.0f;
            }
        }

        public static float GetBusinessHourlyIncome(string businessName)
        {
            if (BusinessPrices.ContainsKey(businessName))
            {
                return BusinessPrices[businessName].HourlyIncome;
            }
            else
            {
                Debug.LogError("Часовой доход для бизнеса " + businessName + " не найден.");
                return 0.0f;
            }
        }

        public static string GetBusinessName(string businessName)
        {
            if (BusinessPrices.ContainsKey(businessName))
            {
                return BusinessPrices[businessName].TypeOfShop.ToString();
            }
            else
            {
                Debug.LogError("Имя для бизнеса " + businessName + " не найдено.");
                return string.Empty;
            }
        }

        public static void SetBusinessPrice(string businessName, float newPrice)
        {
            if (BusinessPrices.ContainsKey(businessName))
            {
                BusinessPrices[businessName].Price = newPrice;
            }
            else
            {
                Debug.LogError("Бизнес " + businessName + " не найден.");
            }
        }
    }
}