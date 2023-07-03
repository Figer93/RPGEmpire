using TMPro;
using UnityEngine;

namespace Economics
{
    public class MoneySystem : IMoneyManager
    {
        public float MoneyBalance { get; set; } = 10000;

        //private TextMeshProUGUI _moneyText;
        //private TextMeshProUGUI _hourlyIncomeText;

        private float hourlyIncome;
        private float _elapsedTime, _timeInterval = 5f;

        private void HourlyIncomeSystem()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _timeInterval)
            {
                int incomeToAdd = Mathf.RoundToInt(hourlyIncome * (_timeInterval / 3600f));
                AddMoney(incomeToAdd);
                _elapsedTime = 0f;
            }
        }
        public void BuyBusiness()
        {
            //if (MoneyBalance >= openingPrice)
            {
                //SubtractMoney(openingPrice);
                AddHourlyIncome(hourlyIncome);
            }
        }

        public float GetBalance()
        {
            return MoneyBalance;
        }

        public void SubtractMoney(float amount)
        {
            if (CheckBalance(amount))
            {
                MoneyBalance -= amount;
                UpdateMoneyText();
            }
        }

        public void AddMoney(float amount)
        {
            MoneyBalance += amount;
        }

        public void AddHourlyIncome(float amount)
        {
            hourlyIncome += amount;
            UpdateMoneyText();
        }

        private bool CheckBalance(float amount)
        {
            if (amount <= MoneyBalance)
            {
                return true;
            }
            else
            {
                Notification();
                return false;
            }
        }

        private void Notification()
        {
            Debug.LogError("Not enough funds to buy the business!");
            Debug.Log($"Your current balance is: {MoneyBalance}");
        }

        private void UpdateMoneyText()
        {
            //_moneyText.text = (moneyBalance == 0) ? "0.00" : NumberFormatter.FormatNumsHelper.FormatNum(moneyBalance);
            //_hourlyIncomeText.text = (hourlyIncome == 0) ? "$ 0.00" : "$ " + NumberFormatter.FormatNumsHelper.FormatNum(hourlyIncome);
        }
    }
}
