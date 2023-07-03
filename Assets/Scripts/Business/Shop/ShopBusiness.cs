using UnityEngine;

public class ShopBusiness : MonoBehaviour
{
    private float _openingPrice;
    private float _hourlyIncome;
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
                _openingPrice = 5000;
                _hourlyIncome = 1000;
                break;
            case ShopTypeEnum.ShopType.ChainOfStores:
                _openingPrice = 15000;
                _hourlyIncome = 2500;
                break;
            case ShopTypeEnum.ShopType.Big:
                _openingPrice = 50000;
                _hourlyIncome = 7000;
                break;
        } 
    }
}

