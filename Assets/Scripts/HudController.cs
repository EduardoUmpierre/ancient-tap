using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour {
    GameObject level;

	// Use this for initialization
	void Start () {
		level = GameObject.Find("HUDLevel");
	}
	
	// Update is called once per frame
	void Update () {
		level.GetComponent<TextMesh>().text = "LEVEL " + Hero.level;
	}
}
