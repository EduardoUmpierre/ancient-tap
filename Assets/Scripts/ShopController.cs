using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour {
    int dpsLevel = 1;
    int dpsPerLevel = 1;
    int dpcLevel = 1;
    int dpcPerLevel = 1;

    Hero hero;
    GameObject dps_01_button;
    GameObject dpc_02_button;

    // Use this for initialization
    void Start ()
    {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        dps_01_button = GameObject.Find("Shop_01_DPS_button");
        dpc_02_button = GameObject.Find("Shop_02_DPC_button");
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateButtonText(dps_01_button, dpsLevel);
        UpdateButtonText(dpc_02_button, dpcLevel);
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
        }

        Debug.Log(type);
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
