using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    Monster monster;
    Vector3 localScale;

    GameObject bar;
    GameObject monsterName;
    GameObject monsterHealth;

	// Use this for initialization
	void Start() {
        bar = gameObject.transform.Find("HBBar").gameObject;
        monsterName = gameObject.transform.Find("HBMonsterName").gameObject;
        monsterHealth = gameObject.transform.Find("HBMonsterHealth").gameObject;
    }
	
	// Update is called once per frame
	void Update() {
        float currentHealth = (100 * (monster.health < 0 ? 0 : monster.health)) / (monster.maxHealth <= 0 ? 1 : monster.maxHealth);

        bar.GetComponent<Image>().fillAmount = currentHealth / 100;
        monsterName.GetComponent<Text>().text = monster.enemyName;
        monsterHealth.GetComponent<Text>().text = monster.health.ToString();
    }

    // Sets the monster
    public void SetMonster(Monster monsterComponent)
    {
        monster = monsterComponent;
    }
}
