using TMPro;
using UnityEngine;

public class ClickSystem : MonoBehaviour
{
    public static ClickSystem instance;
    
    
    public float _clickPower = 1;
    
    [SerializeField] private TextMeshProUGUI _clickText;
    
    [SerializeField] private LevelSystem _levelSystem;
    [SerializeField] private MoneySystem _moneySystem;

    void Start()
    {
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
        _clickText.text = _clickPower.ToString("$ "+ _clickPower);
    }
    public void Click()
    {
        _moneySystem.moneyBalance += _clickPower;
        float clickValue = _levelSystem.levelMultiplier * _clickPower;
        _levelSystem.levelExpirience += clickValue;
    }
}
