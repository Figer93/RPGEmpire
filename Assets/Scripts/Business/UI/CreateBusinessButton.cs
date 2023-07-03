using UnityEngine;
using UnityEngine.UI;

public class CreateBusinessButton : MonoBehaviour
{
    [SerializeField] private BusinessManager _businessManager;
    private Button _buyBusinessButton;

    void Start()
    {
        _buyBusinessButton = GetComponent<Button>();
        _buyBusinessButton.onClick.AddListener(_businessManager.InstantiateNewBusiness); 
    }
}
