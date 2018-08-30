using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTimer : MonoBehaviour {
    public GameObject timerObject;

    Text timer;
    Hero hero;
    float timeLeft = 20.0f;

    // Use this for initialization
    void Start ()
    {
        timer = timerObject.GetComponent<Text>();
        hero = GameObject.Find("Hero").GetComponent<Hero>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        timeLeft -= Time.deltaTime;

        timer.text = timeLeft.ToString("N2");

        if (timeLeft < 0)
        {
            Hero.level -= 1;

            hero.DestroyMonster();
            Destroy(gameObject);
        }
    }
}
