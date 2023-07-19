using System.Collections.Generic;
using Economics;
using UnityEngine;

public class BusinessManager : MonoBehaviour, IBusinessControl
{
    private IMoneyManager _moneySystem;
    private BusinessTemplate _newBusiness;

    [SerializeField] private Transform _businessStorageTransform;
    [SerializeField] private BusinessTemplate _businessPrefabTemplate;
    [SerializeField] private CreateNameBusiness _createNameBusiness;
    [SerializeField] private ShopBusiness _shopBusiness;

    private void Start()
    {
        _moneySystem = new MoneySystem();
    }
    
    public void BuyBusiness()
    {
        _moneySystem.SubtractMoney(_shopBusiness.OpeningPrice);
        InstantiateNewBusiness();
        SetupBusiness(_newBusiness.BusinessName, _newBusiness.HourlyIncome);
        AddNewBusiness(_newBusiness);
    }

    private void InstantiateNewBusiness()
    {
        _newBusiness = Instantiate(_businessPrefabTemplate, _businessStorageTransform);
    }

    private void SetupBusiness(string businessName, float businessIncome)
    {
        _createNameBusiness.SetupShopName(businessName);
        _moneySystem.AddHourlyIncome(businessIncome);
    }

    public List<BusinessTemplate> BusinessesList()
    {
        BusinessTemplate[] businessArray = _businessStorageTransform.GetComponentsInChildren<BusinessTemplate>();
        List<BusinessTemplate> businessList = new List<BusinessTemplate>(businessArray);
        return businessList;
    }

    public void AddNewBusiness(BusinessTemplate business)
    {
        List<BusinessTemplate> businessList = BusinessesList();
        businessList.Add(business);
    }

    public void GetBusinessesList()
    {
        List<BusinessTemplate> businessList = BusinessesList();
        Debug.Log($"You have {businessList.Count} businesses");
    }
}
