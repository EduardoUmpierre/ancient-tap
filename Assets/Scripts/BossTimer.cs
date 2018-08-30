using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTimer : MonoBehaviour {
    public GameObject timerObject;

    GameObject monster;
    Monster monsterComponent;
    Text timer;
    Hero hero;
    float timeLeft = 20.0f;
    int milliseconds;

    // Use this for initialization
    void Start ()
    {
        monster = GameObject.FindGameObjectsWithTag("Enemy")[0];
        monsterComponent = monster.GetComponent<Monster>();

        timer = timerObject.GetComponent<Text>();
        hero = GameObject.Find("Hero").GetComponent<Hero>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        timeLeft -= Time.deltaTime;
        milliseconds = (int)(timeLeft * 1000f) % 1000;

        timer.text = timeLeft.ToString("N2");

        if (timeLeft < 0)
        {
            Hero.level -= 1;

            hero.DestroyMonster();
            Destroy(gameObject);
        }
    }
}
