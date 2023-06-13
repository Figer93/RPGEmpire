using System;
using TMPro;
using UnityEngine;

public class CheckCurrentTime : MonoBehaviour
{
    private int _hour, _minute;
    [SerializeField] private TextMeshProUGUI _timeText;

    private void Update()
    {
        _hour = DateTime.Now.Hour;
        _minute = DateTime.Now.Minute;
        _timeText.text = _hour.ToString("##:" + _minute);
    }
}
