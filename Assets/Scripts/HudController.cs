using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour {
    GameObject level;
    GameObject coins;

	// Use this for initialization
	void Start() {
		level = GameObject.Find("HUDLevel");
        coins = GameObject.Find("HUDCoins");
    }
	
	// Update is called once per frame
	void Update() {
		level.GetComponent<TextMesh>().text = "LEVEL " + Hero.level;
        coins.GetComponent<TextMesh>().text = Hero.coins.ToString();
    }
}
