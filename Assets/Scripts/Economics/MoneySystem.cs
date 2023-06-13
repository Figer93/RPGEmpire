using TMPro;
using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    public float moneyBalance = 10000; 

    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _hourlyIncomeText;

    public float hourlyIncome = 0;
    private float _timeInterval = 5f;
    private float _elapsedTime = 0f;
    
    private void Update()
    {
        UpdateMoneyText();
        HourlyIncomeSystem();
    }

    private void HourlyIncomeSystem()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _timeInterval)
        {
            int incomeToAdd = Mathf.RoundToInt(hourlyIncome * (_timeInterval / 3600f));
            IncreaseMoneyBalance(incomeToAdd);
            _elapsedTime = 0f;
        }
    }
    private void IncreaseMoneyBalance(int income)
    {
        moneyBalance += income;
    }

    public void SubtractMoney(float amount)
    {
        moneyBalance -= amount;
        UpdateMoneyText();
    }

    public void AddHourlyIncome(float income)
    {
        hourlyIncome += income;
        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        _moneyText.text = (moneyBalance == 0) ? "0.00" : moneyBalance.ToString("##.##");
        _hourlyIncomeText.text = (hourlyIncome == 0) ? "$ 0.00" : "$ " + hourlyIncome.ToString("##.##");
    }

}
