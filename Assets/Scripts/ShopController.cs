using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour {
    int dpsLevel = 1;
    float dpsPerLevel = 1f;

    int dpcLevel = 1;
    float dpcPerLevel = 1f;

    int critChanceLevel = 1;
    float critChancePerLevel = 1.05f;

    int critDamageLevel = 1;
    float critDamagePerLevel = 1.15f;

    int goldBonusLevel = 1;
    float goldBonusPerLevel = 1.025f;

    Hero hero;
    GameObject dpsButton;
    GameObject dpcButton;
    GameObject critChanceButton;
    GameObject critDamageButton;
    GameObject goldBonusButton;

    // Use this for initialization
    void Start ()
    {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        dpsButton = GameObject.Find("Shop_01_DPS_button");
        dpcButton = GameObject.Find("Shop_02_DPC_button");
        critChanceButton = GameObject.Find("Shop_03_CRITCHANCE_button");
        critDamageButton = GameObject.Find("Shop_04_CRITDAMAGE_button");
        goldBonusButton = GameObject.Find("Shop_05_GOLDBONUS_button");

    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateButtonText(dpsButton, dpsLevel);
        UpdateButtonText(dpcButton, dpcLevel);
        UpdateButtonText(critChanceButton, critChanceLevel);
        UpdateButtonText(critDamageButton, critDamageLevel);
        UpdateButtonText(goldBonusButton, goldBonusLevel);
    }

    //
    public void ButtonClick(string type)
    {
        switch (type)
        {
            case "dps":
                if (hero.Upgrade(type, dpsPerLevel, GetCost(dpsLevel)))
                {
                    dpsLevel++;
                }               
                break;
            case "dpc":
                if (hero.Upgrade(type, dpcPerLevel, GetCost(dpcLevel)))
                {
                    dpcLevel++;
                }
                break;
            case "crit_chance":
                if (hero.Upgrade(type, critChancePerLevel, GetCost(critChanceLevel)))
                {
                    critChanceLevel++;
                }
                break;
            case "crit_damage":
                if (hero.Upgrade(type, critDamagePerLevel, GetCost(critDamageLevel)))
                {
                    critDamageLevel++;
                }
                break;
            case "gold_bonus":
                if (hero.Upgrade(type, goldBonusPerLevel, GetCost(goldBonusLevel)))
                {
                    goldBonusLevel++;
                }
                break;
        }
    }

    //
    private int GetCost(int level)
    {
        return level * 10;
    }

    //
    private void UpdateButtonText(GameObject button, int level)
    {
        button.GetComponentInChildren<Text>().text = "$" + GetCost(level).ToString();
    }
}
