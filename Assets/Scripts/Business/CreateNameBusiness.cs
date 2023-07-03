using System;
using TMPro;
using UnityEngine;

public class CreateNameBusiness : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameInputField;
    public string storeName;

    private void OnEnable()
    {
        RefreshName();
    }

    public void InputName()
    {
        storeName = _nameInputField.text;
    }

    private void RefreshName()
    {
        _nameInputField.text = String.Empty;
    }
    
    public void SetupShopName(string shopName)
    {
        string empty = "Shop";
        if (string.IsNullOrEmpty(shopName))
        {
            storeName = empty;
        }
        else
        {
            storeName = shopName;
        }
    }
}
