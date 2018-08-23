using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
    public GameObject monsterObject;

    Monster monster;
    Vector3 localScale;

	// Use this for initialization
	void Start() {
        monster = monsterObject.GetComponent<Monster>();
        localScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update() {
        int currentHealth = (100 * monster.health) / monster.maxHealth;

		localScale.x = currentHealth < 0 ? 0 : currentHealth;
        transform.localScale = localScale;
	}
}
