using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save {
    public int level;
    public float coins;

    public float damagePerSecond;
    public float damagePerClick;
    public float criticalChance;
    public float criticalDamage;
    public float goldBonus;

    public Dictionary<string, Dictionary<string, object>> shopListItems;
}