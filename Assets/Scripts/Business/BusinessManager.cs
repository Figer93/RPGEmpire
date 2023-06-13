using System;
using TMPro;
using UnityEngine;

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

    [SerializeField] private GameObject _image; // Information picture about creating new business(should switch off when you have any business)
    
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

    private void InstantiateNewBusiness()
    {
        _newBusinessTemplate = Instantiate(_businessPrefabTemplate, _businessStorageTransform);
        _businessStorage.shopStorage.Add(_newBusinessTemplate.GetComponent<ShopController>());
    }

    private void SetUpNewBusiness()
    {
        ShopController newShopController = _newBusinessTemplate.GetComponent<ShopController>();
        newShopController.SetupShop(_businessName, _shopBusiness.shopType, openingPrice, hourlyIncome);
    }
}
