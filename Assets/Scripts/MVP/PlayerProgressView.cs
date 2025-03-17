using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerProgressView : MonoBehaviour
{
    public abstract void UpdateXP(int xp);
    public abstract void UpdateLevel(int level);
}
