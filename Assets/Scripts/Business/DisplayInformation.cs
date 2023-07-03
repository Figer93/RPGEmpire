using UnityEngine;
using TMPro;

public class DisplayInformation : MonoBehaviour
{
    public Sprite icon;
    public TextMeshProUGUI shopNameTxt;
    public TextMeshProUGUI shopCategoryTxt;
    public TextMeshProUGUI hourlyIncomeTxt;

    void OnEnable()
    {
        BusinessTemplate.OnBusinessClicked += UpdateDisplay;
    }

    void OnDisable()
    {
        BusinessTemplate.OnBusinessClicked -= UpdateDisplay;
    }

    void UpdateDisplay(string shopName, string shopCategory, float hourlyIncome)
    {
        shopNameTxt.text = shopName;
        shopCategoryTxt.text = shopCategory;
        hourlyIncomeTxt.text = "$ " + NumberFormatter.FormatNumsHelper.FormatNum(hourlyIncome);
    }
}