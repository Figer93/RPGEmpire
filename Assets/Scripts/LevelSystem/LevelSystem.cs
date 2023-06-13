using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    private int _level, _nextLevel;
    public float levelExpirience,  maxLevelExpirience = 1000;
    public float levelMultiplier = 1.00f;
    
    [SerializeField] private TextMeshProUGUI _levelText, _nextLevelText, _levelExpirienceText;
    [SerializeField] private Slider _expirienceBar;

    private void Start()
    {
        LevelControl();
        NextLevelCalculate(_level);
    }

    private void Update()
    {
        _expirienceBar.maxValue = maxLevelExpirience;
        UpdateLevelSlider(levelExpirience);
        LevelControl();
    }

    private void LevelControl()
    {
        LevelTextUpdate();
        IsLevelUp();
    }

    private void NextLevelCalculate(int value)
    {
        _nextLevel = 1 + value;
    }

    private void IsLevelUp()
    {
        if (levelExpirience >= maxLevelExpirience)
        {
            _level++;
            maxLevelExpirience += 1300;
            levelMultiplier += 0.2f;
            NextLevelCalculate(_level);
            ClickSystem.instance._clickPower++;
            levelExpirience = 0;
        }
    }

    private void UpdateLevelSlider(float value)
    {
        _expirienceBar.value = value;
        _levelExpirienceText.text = (levelExpirience == 0) ? "0 Exp" : levelExpirience.ToString("##.##") + " Exp";
    }

    private void LevelTextUpdate()
    {
        _levelText.text = _level.ToString(_level + " level");
        _nextLevelText.text = _nextLevel.ToString(_nextLevel + " level");
    }
}
