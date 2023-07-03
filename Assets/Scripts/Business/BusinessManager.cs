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

    private void Start()
    {
        _moneySystem = new MoneySystem();
    }

    public void InstantiateNewBusiness()
    {
        BuyBusiness(_newBusiness.BusinessCost);
        _newBusiness = Instantiate(_businessPrefabTemplate, _businessStorageTransform);
        AddNewBusiness(_newBusiness);
        SetupBusiness(_newBusiness.BusinessName, _newBusiness.HourlyIncome);
    }

    private void BuyBusiness(float businessCost)
    {
        _moneySystem.SubtractMoney(businessCost);
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
