using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerProgressData
{
    [SerializeField] private int xp;
    [SerializeField] private int level;

    public int XP => xp;
    public int Level => level;

    public PlayerProgressData(int xp, int level)
    {
        this.xp = xp;
        this.level = level;
    }
}
