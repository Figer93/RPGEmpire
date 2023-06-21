using TMPro;
using System;
using UnityEngine;

public class NewBusinessTemplate : MonoBehaviour
{
    public string shopName;
    public string businessCategory;
    public ShopType shopType;
    public float hourlyIncome;
    
    public static event Action<string, string, float> OnShopClicked;

    [SerializeField] private TextMeshProUGUI shopNameTxt, shopTypeTxt, hourlyIncomeTxt;

    public void SetupShop(string name, string category, ShopType type, int price, float income)
    {
        SetupShopName(name);
        businessCategory = category;
        shopType = type;
        hourlyIncome = income;
        UpdateUiInformation();
    }

    private void SetupShopName(string shopName)
    {
        if (string.IsNullOrEmpty(shopName))
        {
            this.shopName = "Shop";
        }
        else
        {
            this.shopName = shopName;
        }
    }
    public void ShopClicked()
    {
        if (OnShopClicked != null) OnShopClicked(shopName, businessCategory, hourlyIncome);
    }
    private void UpdateUiInformation()
    {
        shopNameTxt.text = shopName;
        shopTypeTxt.text = shopType.ToString();
        hourlyIncomeTxt.text = "$ " + NumberFormatter.FormatNumsHelper.FormatNum(hourlyIncome) + " <size=30><color=#9A9A9A>Per click</color>";
    }
}
