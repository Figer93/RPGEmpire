using TMPro;
using UnityEngine;

public class CreateNameStore : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputText;
    public string storeName;
    public bool isShopNamed = false;

    public void InputText()
    {
        storeName = _inputText.text;
        CheckShopName();
    }

    private void CheckShopName()
    {
        if(storeName == _inputText.text)
        {
            isShopNamed = true;
        }
        else
        {
            isShopNamed = false;
        }
    }
}
