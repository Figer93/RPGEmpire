using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public string shopName;
    public ShopType shopType;
    public int hourlyIncome;
    
    public static event System.Action<string, int> OnShopClicked;

    [SerializeField] private TextMeshProUGUI shopNameTxt, shopTypeTxt, hourlyIncomeTxt;

    public void SetupShop(string name, ShopType type, int price, int income)
    {
        SetupShopName(name);
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
        if (OnShopClicked != null)
        {
            OnShopClicked(shopType.ToString(), hourlyIncome);
        }
    }
    private void UpdateUiInformation()
    {
        shopNameTxt.text = shopName;
        shopTypeTxt.text = shopType.ToString();
        hourlyIncomeTxt.text = "$ " + hourlyIncome.ToString("##.#");
    }
}
