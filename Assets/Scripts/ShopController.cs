using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour {
    int dpsLevel = 1;
    int dpsPerLevel = 1;

    Hero hero;

	// Use this for initialization
	void Start () {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //
    public void ButtonClick(string type)
    {
        switch (type)
        {
            case "dps":
                hero.increaseDPS(dpsPerLevel);
                Debug.Log(hero.damagePerSecond);
                dpsLevel++;
                break;
        }

        Debug.Log(type);
    }
}
