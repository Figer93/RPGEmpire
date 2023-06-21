using System.Collections.Generic;
using UnityEngine;

public class BusinessStorage : MonoBehaviour
{
    public List<NewBusinessTemplate> shopStorage;
    private BusinessManager _businessManager;

    private void Start()
    {
        _businessManager = GetComponent<BusinessManager>();
        FillBusinessList();
    }

    private void FillBusinessList()
    {
        shopStorage.Clear();
        NewBusinessTemplate[] shopControllers = _businessManager._businessStorageTransform.GetComponentsInChildren<NewBusinessTemplate>();
        shopStorage.AddRange(shopControllers);
    }
}
