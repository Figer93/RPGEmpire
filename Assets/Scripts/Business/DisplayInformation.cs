using UnityEngine;
using TMPro;

public class DisplayInformation : MonoBehaviour
{
    public TextMeshProUGUI shopTypeTxt;

    public TextMeshProUGUI hourlyIncomeTxt;

    void OnEnable()
    {
        ShopController.OnShopClicked += UpdateDisplay;
    }

    void OnDisable()
    {
        ShopController.OnShopClicked -= UpdateDisplay;
    }

    void UpdateDisplay(string shopType, int hourlyIncome)
    {
        shopTypeTxt.text = shopType;
        hourlyIncomeTxt.text = "$ " + hourlyIncome.ToString("##.#");
    }
}