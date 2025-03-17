using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class LevelUp : MonoBehaviour
{
    [SerializeField, Min(0)] private int _xpUp = 10;
    [SerializeField] private PlayerProgressPresenter _progressPresenter;
    [SerializeField] private TextMeshProUGUI _textLevel;
    [SerializeField] private TextMeshProUGUI _textXP;


    [Inject]
    public void Construct(PlayerProgressPresenter progressPresenter)
    {
        _progressPresenter = progressPresenter;

        _progressPresenter.OnXPUpdated += UpdateXP;
        _progressPresenter.OnLevelUpdated += UpdateLevel;

        UpdateXP(_progressPresenter.GetCurrentXP());
        UpdateLevel(_progressPresenter.GetCurrentLevel());
    }

    private void OnDestroy()
    {
        if (_progressPresenter != null)
        {
            _progressPresenter.OnXPUpdated -= UpdateXP;
            _progressPresenter.OnLevelUpdated -= UpdateLevel;
        }
    }

    public void Click()
    {
        _progressPresenter.AddXP(_xpUp);
    }

    private void UpdateXP(int xp)
    {
        _textXP.text = xp.ToString(); 
    }

    private void UpdateLevel(int level)
    {
        _textLevel.text = level.ToString();
    }



}
