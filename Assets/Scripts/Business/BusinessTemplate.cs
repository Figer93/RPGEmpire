using System;
using UnityEngine;

public class BusinessTemplate : MonoBehaviour
{
    public string BusinessName, BusinessCategory;
    public float BusinessCost, HourlyIncome;
    public ShopTypeEnum.ShopType shopType;
    
    public static event Action<string, string, float> OnBusinessClicked;
    public void ShopClicked()
    {
        if (OnBusinessClicked != null) OnBusinessClicked(BusinessName, BusinessCategory, HourlyIncome);
    }
}
