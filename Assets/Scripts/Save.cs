using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save {
    public int level;
    public int coins;

    public int damagePerSecond;
    public int damagePerClick;
    public float criticalChance;
    public float criticalDamage;
    public float goldBonus;

    public Dictionary<string, Dictionary<string, float>> shopListItems;
}