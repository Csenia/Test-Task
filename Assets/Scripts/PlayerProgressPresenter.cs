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

    public event Action<int> OnXPUpdated; // Событие для обновления XP
    public event Action<int> OnLevelUpdated; // Событие для обновления Level

    [Inject]
    public PlayerProgressPresenter(XPData xpData, LevelData levelData)
    {
        _xpData = xpData;
        _levelData = levelData;
    }

    public async Task AddXP(int amount)
    {
        _xpData.AddXP(amount);
        OnXPUpdated?.Invoke(_xpData.XP); // Обновляем UI
        await CheckLevelUp();
    }

    private async Task CheckLevelUp()
    {
        if (_xpData.XP >= 100)
        {
            _levelData.LevelUp();
            _xpData.AddXP(-100);
            OnLevelUpdated?.Invoke(_levelData.Level); // Обновляем UI
            OnXPUpdated?.Invoke(_xpData.XP); // Обновляем UI после сброса XP
        }
    }

    public int GetCurrentXP() => _xpData.XP; // Получаем текущее значение XP
    public int GetCurrentLevel() => _levelData.Level; // Получаем текущее значение Level
}
