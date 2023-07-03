using Economics;
using TMPro;
using UnityEngine;

public class ClickSystem : MonoBehaviour
{
    public static ClickSystem instance;
    
    
    public float _clickPower = 1;
    
    [SerializeField] private TextMeshProUGUI _clickText;
    
    [SerializeField] private LevelSystem _levelSystem;
    
    private MoneySystem _moneySystem;

    void Start()
    {
        _moneySystem = new MoneySystem();
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        _clickText.text = "$ " + NumberFormatter.FormatNumsHelper.FormatNum(_clickPower) + " <size=40><color=#FFFFFFB9><b>Per click</b></color>";
    }
    public void Click()
    {
        _moneySystem.MoneyBalance += _clickPower;
        float clickValue = _levelSystem.levelMultiplier * _clickPower;
        _levelSystem.levelExpirience += clickValue;
    }
}
