using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour {
    GameObject level;
    GameObject coins;

	// Use this for initialization
	void Start() {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

		level = GameObject.Find("HUDLevel");
        coins = GameObject.Find("HUDCoins");
    }
	
	// Update is called once per frame
	void Update() {
		level.GetComponent<Text>().text = "Level " + Hero.level;
        coins.GetComponent<Text>().text = Hero.coins.ToString();
    }
}
