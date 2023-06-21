using System;
using TMPro;
using UnityEngine;

public enum BusinessCategory
{
    [StringValue("Food industry")]
    FoodIndustry,

    [StringValue("Manufacture")]
    Manufacture,

    [StringValue("Transportation")]
    Transportation
}
public static class EnumExtensions
{
    public static string GetStringValue(this Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var stringValueAttribute = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

        return stringValueAttribute.Length > 0 ? stringValueAttribute[0].Value : value.ToString();
    }
}

public class StringValueAttribute : Attribute
{
    public string Value { get; }

    public StringValueAttribute(string value)
    {
        Value = value;
    }
}

public class BusinessManager : MonoBehaviour
{
    public int openingPrice;
    public int hourlyIncome;
    
    private GameObject _newBusinessTemplate;
    private string _businessName;

    private BusinessStorage _businessStorage;
    private Shop _shopBusiness;
    [SerializeField] private MoneySystem _moneySystem;

    public Transform _businessStorageTransform;
    [SerializeField] private GameObject _businessPrefabTemplate;

    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private TextMeshProUGUI _costNameOpenTxt;

    #region Other

    [SerializeField] private GameObject _image; // Information picture about creating new business(should switch off when you have any business)

    #endregion

    private void Start()
    {
        _businessStorage = GetComponent<BusinessStorage>();
        _shopBusiness = GetComponent<Shop>();
        
        IsAnyBusinessPresent();
    }

    public void OnSetName()
    {
        _businessName = nameInputField.text;
    }

    public void OnBuyBusiness()
    {
        float playerBalance = _moneySystem.moneyBalance;
        if (playerBalance >= openingPrice)
        {
            _moneySystem.SubtractMoney(openingPrice);
            _moneySystem.AddHourlyIncome(hourlyIncome);
            InstantiateNewBusiness();
            SetUpNewBusiness();
            IsAnyBusinessPresent();
        }
        else
        {
            Debug.Log("Not enough funds to buy the store! " + "Your current balance is: " + _moneySystem.moneyBalance);
        }
    }

    public void RefreshName()
    {
        nameInputField.text = String.Empty;
    }

    public void UpdateOpeningPriceText()
    {
        _costNameOpenTxt.text = "$ " + openingPrice.ToString("##.##");
    }
    
    public void IsAnyBusinessPresent()
    {
        if (_businessStorage.shopStorage.Count > 0)
        {
            _image.SetActive(false);
        }
        else
        {
            _image.SetActive(true);
        }
    }

    public void EnableDisplayInfo()
    {
        _newBusinessTemplate.gameObject.SetActive(true);
    }

    private void InstantiateNewBusiness()
    {
        _newBusinessTemplate = Instantiate(_businessPrefabTemplate, _businessStorageTransform);
        _businessStorage.shopStorage.Add(_newBusinessTemplate.GetComponent<NewBusinessTemplate>());
    }

    private void SetUpNewBusiness()
    {
        NewBusinessTemplate newNewBusinessTemplate = _newBusinessTemplate.GetComponent<NewBusinessTemplate>();
        newNewBusinessTemplate.SetupShop(_businessName, _shopBusiness.businessCategory, _shopBusiness.shopType, openingPrice, hourlyIncome);
    }
}
