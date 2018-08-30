using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ShopController : MonoBehaviour {
    public static Dictionary<string, Dictionary<string, object>> shopController = new Dictionary<string, Dictionary<string, object>>();
    public GameObject shopListPrefab;
    public GameObject shopControllerContainer;

    Hero hero;
    Dictionary<string, object> shopListItems = new Dictionary<string, object>();

    // Use this for initialization
    void Start ()
    {
        if (shopController.Count == 0)
        {
            SetUpShopListItems();
        }

        GenerateShopListItems();

        hero = GameObject.Find("Hero").GetComponent<Hero>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateItems();
    }

    //
    void ButtonClick(string type)
    {
        float total = (float)shopController[type]["total"];
        float level = (float)shopController[type]["level"];
        float amount = (float)shopController[type]["amountPerLevel"];

        if (hero.Upgrade(type, amount, GetCost(level)))
        {
            shopController[type]["level"] = level + 1;
            shopController[type]["total"] = total + (float)shopController[type]["displayAmountPerLevel"];
        }  
    }

    //
    private int GetCost(float level)
    {
        return Mathf.CeilToInt(level * (int) (level * 10));
    }

    // Initialize the shop list items
    private void SetUpShopListItems()
    {
        shopController.Add("dps", SetUpItemConfiguration("Timety", "DPS", "", 1f, 1f, 1f, 0f));
        shopController.Add("dpc", SetUpItemConfiguration("Hitter", "DPC", "", 1f, 1f, 1f, 0f));
        shopController.Add("crit_chance", SetUpItemConfiguration("Storment", "Crit Chance", "%", 1f, 0.5f, 0.5f, 0f));
        shopController.Add("crit_damage", SetUpItemConfiguration("Brutus", "Crit Damage", "%", 1f, 0.15f, 15f, 0f));
        shopController.Add("gold_bonus", SetUpItemConfiguration("Yggdrasill of Fortune", "Gold Bonus", "%", 1f, 0.05f, 5f, 0f));
    }

    // Shop list item setup
    private Dictionary<string, object> SetUpItemConfiguration(string name, string description, string type, float level, float amountPerLevel, float displayAmountPerLevel, float total)
    {
        Dictionary<string, object> itemConfiguration = new Dictionary<string, object>
        {
            { "name", name },
            { "description", description },
            { "type", type },
            { "level", level },
            { "amountPerLevel", amountPerLevel },
            { "displayAmountPerLevel", displayAmountPerLevel },
            { "total", total }
        };

        return itemConfiguration;
    }

    // shopController getter
    public static Dictionary<string, Dictionary<string, object>> GetshopController()
    {
        return shopController;
    }

    // shopController setter
    public void SetshopController(Dictionary<string, Dictionary<string, object>> items)
    {
        shopController = items;
    }

    // Generates the shop list items
    private void GenerateShopListItems()
    {
        float incrementFactor = 0.888f;
        float i = 0.888f * shopController.Count / 7;
        float y;

        foreach (KeyValuePair<string, Dictionary<string, object>> entry in shopController)
        {
            y = (0.888f * 7 / shopController.Count) + i;

            GameObject shopItem = Instantiate(shopListPrefab, new Vector3(-0.1f, -y, 0), Quaternion.identity, shopControllerContainer.transform);
            shopItem.transform.Find("Name").GetComponent<Text>().text = entry.Value["name"].ToString();
            shopItem.transform.Find("Button").GetComponent<Button>().onClick.AddListener(() => ButtonClick(entry.Key));

            UpdateItemInformation(shopItem.transform.Find("Information").GetComponent<Text>(), entry.Key);

            shopListItems.Add(entry.Key, shopItem);

            i += incrementFactor;
        }

        // Parent resize
        RectTransform parentRectTransform = shopControllerContainer.transform.parent.GetComponent<RectTransform>();
        parentRectTransform.sizeDelta = new Vector2(parentRectTransform.sizeDelta.x, 125 * shopController.Count);
    }

    //
    private void UpdateItems()
    {
        foreach (KeyValuePair<string, Dictionary<string, object>> entry in shopController)
        {
            GameObject item = (GameObject) shopListItems[entry.Key];
            GameObject button = item.transform.Find("Button").gameObject;
            Text information = item.transform.Find("Information").GetComponent<Text>();

            UpdateButtonText(button, entry.Key);
            UpdateItemInformation(information, entry.Key);
        }
    }

    //
    private void UpdateItemInformation(Text textComponent, string type)
    {
        textComponent.text = "Lv. " + shopController[type]["level"].ToString() + "\n" + shopController[type]["description"].ToString() + ": +" + shopController[type]["total"].ToString() + shopController[type]["type"];
    }

    //
    private void UpdateButtonText(GameObject button, string type)
    {
        Button buttonComponent = button.GetComponent<Button>();
        int cost = GetCost((float) shopController[type]["level"]);

        button.GetComponentInChildren<Text>().text = "$ " + cost.ToString() + "\n" + shopController[type]["description"] + " +" + shopController[type]["displayAmountPerLevel"] + shopController[type]["type"];

        if (cost > Hero.coins)
        {
            buttonComponent.interactable = false;
        }
        else
        {
            buttonComponent.interactable = true;
        }
    }
}
