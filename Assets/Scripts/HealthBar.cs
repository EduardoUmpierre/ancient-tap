using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
    Monster monster;
    Vector3 localScale;

	// Use this for initialization
	void Start() {
        monster = GameObject.FindGameObjectsWithTag("Enemy")[0].GetComponent<Monster>();
        localScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update() {
        int currentHealth = (100 * (monster.health < 0 ? 0 : monster.health)) / (monster.maxHealth <= 0 ? 1 : monster.maxHealth);

		localScale.x = currentHealth < 0 ? 0 : currentHealth;
        transform.localScale = localScale;
	}
}
