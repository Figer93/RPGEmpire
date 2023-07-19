using System;
using UnityEngine;

public class ShopBusiness : MonoBehaviour
{
    public float OpeningPrice, HourlyIncome;
    private BusinessCategoryEnum.BusinessCategory _businessCategory;
    private ShopTypeEnum.ShopType _shopType;

    private void Start()
    {
        _businessCategory = BusinessCategoryEnum.BusinessCategory.FoodIndustry;
    }

    public void OnChooseShopType(int shopType)
    {
        _shopType = (ShopTypeEnum.ShopType) shopType;
        SetShopType(_shopType);
    }
    
    private void SetShopType(ShopTypeEnum.ShopType shopType)
    {
        switch (shopType)
        {
            case ShopTypeEnum.ShopType.Small:
                OpeningPrice = 5000;
                HourlyIncome = 1000;
                break;
            case ShopTypeEnum.ShopType.ChainOfStores:
                OpeningPrice = 15000;
                HourlyIncome = 2500;
                break;
            case ShopTypeEnum.ShopType.Big:
                OpeningPrice = 50000;
                HourlyIncome = 7000;
                break;
        } 
    }
}

