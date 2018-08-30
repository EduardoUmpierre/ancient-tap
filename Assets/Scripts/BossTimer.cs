using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTimer : MonoBehaviour {
    public GameObject timerObject;

    HudController HUDController;
    Text timer;
    Hero hero;
    float timeLeft = 20.0f;

    // Use this for initialization
    void Start ()
    {
        timer = timerObject.GetComponent<Text>();
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        HUDController = GameObject.Find("HudController").GetComponent<HudController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (timeLeft <= 0f)
        {
            timeLeft = 0f;

            Hero.level -= 1;
            hero.DestroyMonster();
            HUDController.SpawnBossFightButton();

            Destroy(gameObject);
        }
        else
        {
            timeLeft -= Time.deltaTime;

            timer.text = timeLeft.ToString("N2");
        }
    }
}
