using System.ComponentModel;
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
    
    private string shopName;
    
    private BusinessManager _businessManager;

    private void Start()
    {
        _businessManager = GetComponent<BusinessManager>();
    }

    public void OnSetShopType(int type)
    {
        shopType = (ShopType)type;
        ChangeShop(shopType);
    }

    private void ChangeShop(ShopType shopType)
    {
        switch (shopType)
        {
            case ShopType.Small:
                _businessManager.openingPrice = 5000;
                _businessManager.hourlyIncome = 1000;
                break;
            case ShopType.ChainOfStores:
                _businessManager.openingPrice = 15000;
                _businessManager.hourlyIncome = 2500;
                break;
            case ShopType.Big:
                _businessManager.openingPrice = 50000;
                _businessManager.hourlyIncome = 7000;
                break;
        }
        _businessManager.UpdateOpeningPriceText();
        _businessManager.RefreshName();
    }
}

