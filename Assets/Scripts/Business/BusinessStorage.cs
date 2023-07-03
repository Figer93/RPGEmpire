using System.Collections.Generic;
using UnityEngine;

public class BusinessStorage : MonoBehaviour
{
    public List<BusinessTemplate> shopStorage;
    private IBusinessControl _businessControl;

    private void Start()
    {
        _businessControl = GetComponent<IBusinessControl>();
        if (_businessControl == null)
        {
            Debug.LogError("BusinessStorage requires a component implementing IBusinessControl.");
        }
        FillBusinessList();
    }

    private void FillBusinessList()
    {
        List<BusinessTemplate> businessList = _businessControl.BusinessesList();
        shopStorage.AddRange(businessList);
    }
}
