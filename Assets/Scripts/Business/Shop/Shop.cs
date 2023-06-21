using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public enum ShopType
{
    [Description("Small")]
    Small,
    
    [Description("Chain of Stores")]
    ChainOfStores,
    
    [Description("Big")]
    Big
}
public class Shop : MonoBehaviour
{
    public ShopType shopType;
    public string businessCategory;
    private BusinessManager _businessManager;

    private void Start()
    {
        _businessManager = GetComponent<BusinessManager>();
        businessCategory = BusinessCategory.FoodIndustry.GetStringValue();
    }

    public void OnSetShopType(int type)
    {
        shopType = (ShopType)type;
        ShopType(shopType);
    }

    private void ShopType(ShopType shopType)
    {
        switch (shopType)
        {
            case global::ShopType.Small:
                _businessManager.openingPrice = 5000;
                _businessManager.hourlyIncome = 1000;
                break;
            case global::ShopType.ChainOfStores:
                _businessManager.openingPrice = 15000;
                _businessManager.hourlyIncome = 2500;
                break;
            case global::ShopType.Big:
                _businessManager.openingPrice = 50000;
                _businessManager.hourlyIncome = 7000;
                break;
        }
        _businessManager.UpdateOpeningPriceText();
        _businessManager.RefreshName();
    }
}

