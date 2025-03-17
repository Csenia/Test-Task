using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Zenject;
using System;

public class PlayerProgressPresenter
{
    private readonly XPData _xpData;
    private readonly LevelData _levelData;

    public event Action<int> OnXPUpdated; 
    public event Action<int> OnLevelUpdated; 

    [Inject]
    public PlayerProgressPresenter(XPData xpData, LevelData levelData)
    {
        _xpData = xpData;
        _levelData = levelData;
    }

    public async Task AddXP(int amount)
    {
        _xpData.AddXP(amount);
        OnXPUpdated?.Invoke(_xpData.XP); 
        await CheckLevelUp();
    }

    private async Task CheckLevelUp()
    {
        if (_xpData.XP >= 100)
        {
            _levelData.LevelUp();
            _xpData.AddXP(-100);
            OnLevelUpdated?.Invoke(_levelData.Level); 
            OnXPUpdated?.Invoke(_xpData.XP); 
        }
    }

    public int GetCurrentXP() => _xpData.XP; 
    public int GetCurrentLevel() => _levelData.Level; 
}
