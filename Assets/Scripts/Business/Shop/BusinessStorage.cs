using System.Collections.Generic;
using UnityEngine;

public class BusinessStorage : MonoBehaviour
{
    public List<ShopController> shopStorage;
    private BusinessManager _businessManager;

    private void Start()
    {
        _businessManager = GetComponent<BusinessManager>();
        FillBusinessList();
    }

    private void FillBusinessList()
    {
        shopStorage.Clear();
        ShopController[] shopControllers = _businessManager._businessStorageTransform.GetComponentsInChildren<ShopController>();
        shopStorage.AddRange(shopControllers);
    }
}
