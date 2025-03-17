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

    public event Action<int> OnXPUpdated; // ������� ��� ���������� XP
    public event Action<int> OnLevelUpdated; // ������� ��� ���������� Level

    [Inject]
    public PlayerProgressPresenter(XPData xpData, LevelData levelData)
    {
        _xpData = xpData;
        _levelData = levelData;
    }

    public async Task AddXP(int amount)
    {
        _xpData.AddXP(amount);
        OnXPUpdated?.Invoke(_xpData.XP); // ��������� UI
        await CheckLevelUp();
    }

    private async Task CheckLevelUp()
    {
        if (_xpData.XP >= 100)
        {
            _levelData.LevelUp();
            _xpData.AddXP(-100);
            OnLevelUpdated?.Invoke(_levelData.Level); // ��������� UI
            OnXPUpdated?.Invoke(_xpData.XP); // ��������� UI ����� ������ XP
        }
    }

    public int GetCurrentXP() => _xpData.XP; // �������� ������� �������� XP
    public int GetCurrentLevel() => _levelData.Level; // �������� ������� �������� Level
}
