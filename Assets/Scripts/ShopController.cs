using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ShopController : MonoBehaviour {
    public static Dictionary<string, Dictionary<string, float>> shopListItems = new Dictionary<string, Dictionary<string, float>>();

    Hero hero;
    GameObject dpsButton;
    GameObject dpcButton;
    GameObject critChanceButton;
    GameObject critDamageButton;
    GameObject goldBonusButton;

    // Use this for initialization
    void Start ()
    {
        if (shopListItems.Count == 0)
        {
            SetUpShopListItems();
        }

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
        UpdateButtonText(dpsButton, shopListItems["dps"]["level"]);
        UpdateButtonText(dpcButton, shopListItems["dpc"]["level"]);
        UpdateButtonText(critChanceButton, shopListItems["crit_chance"]["level"]);
        UpdateButtonText(critDamageButton, shopListItems["crit_damage"]["level"]);
        UpdateButtonText(goldBonusButton, shopListItems["gold_bonus"]["level"]);
    }

    //
    public void ButtonClick(string type)
    {
        float level = shopListItems[type]["level"];
        float amount = shopListItems[type]["amountPerLevel"];

        if (hero.Upgrade(type, amount, GetCost(level)))
        {
            shopListItems[type]["level"] = level + 1;
        }  
    }

    //
    private int GetCost(float level)
    {
        return Mathf.CeilToInt(level * (int) ((level * 1.5) * 10));
    }

    //
    private void UpdateButtonText(GameObject button, float level)
    {
        button.GetComponentInChildren<Text>().text = "$" + GetCost(level).ToString();
    }

    //
    private void SetUpShopListItems()
    {
        shopListItems.Add("dps", SetUpItemConfiguration(1f, 1f));
        shopListItems.Add("dpc", SetUpItemConfiguration(1f, 1f));
        shopListItems.Add("crit_chance", SetUpItemConfiguration(1f, 1.05f));
        shopListItems.Add("crit_damage", SetUpItemConfiguration(1f, 1.15f));
        shopListItems.Add("gold_bonus", SetUpItemConfiguration(1f, 1.025f));
    }

    //
    private Dictionary<string, float> SetUpItemConfiguration(float level, float amountPerLevel)
    {
        Dictionary<string, float> itemConfiguration = new Dictionary<string, float>
        {
            { "level", level },
            { "amountPerLevel", amountPerLevel }
        };

        return itemConfiguration;
    }

    //
    public Dictionary<string, Dictionary<string, float>> GetShopListItems()
    {
        return shopListItems;
    }

    //
    public void SetShopListItems(Dictionary<string, Dictionary<string, float>> items)
    {
        shopListItems = items;

        Debug.Log(items.ToString());
    }
}
