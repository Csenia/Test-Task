using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class XPData
{
    [SerializeField] private int xp;
    public int XP => xp;

    public void AddXP(int amount)
    {
        xp += amount;
        
    }
}

[Serializable]
public class LevelData
{
    [SerializeField] private int level;
    public int Level => level;

    public void LevelUp()
    {
        level++;
    }

}
