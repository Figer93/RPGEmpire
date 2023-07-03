using TMPro;
using UnityEngine;

public class BusinessTemplateUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _shopNameTxt, _shopTypeTxt, _hourlyIncomeTxt;
    private BusinessTemplate _businessTemplate;

    private void Start()
    {
        _businessTemplate = GetComponent<BusinessTemplate>();
    }

    private void Update()
    {
        UpdateUiInformation();
    }

    private void UpdateUiInformation()
    {
        _shopNameTxt.text = _businessTemplate.BusinessName;
        _shopTypeTxt.text = _businessTemplate.shopType.ToString();
        _hourlyIncomeTxt.text = "$ " + NumberFormatter.FormatNumsHelper.FormatNum(_businessTemplate.HourlyIncome) + " <size=30><color=#9A9A9A>Per click</color>";
    }
}
