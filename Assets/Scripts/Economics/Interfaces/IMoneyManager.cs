public interface IMoneyManager
{
    float GetBalance();
    void SubtractMoney(float amount);
    void AddMoney(float amount);
    void AddHourlyIncome(float amount);
}
