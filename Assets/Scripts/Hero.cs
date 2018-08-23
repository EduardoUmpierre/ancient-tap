using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
    public static int level = 1;
    public static int damagePerClick = 1;
    public static int damagePerSecond = 1;
    public static int coins = 0;

    MonsterSpawner monsterSpawner;
    Monster monsterComponent;
    GameObject monster;

	// Use this for initialization
	void Start() {
        monster = GameObject.FindGameObjectsWithTag("Enemy")[0];
        monsterComponent = monster.GetComponent<Monster>();
		monsterSpawner = GameObject.Find("Spawner").GetComponent<MonsterSpawner>();

        // Invokes the DPS function
        InvokeRepeating("HitPerSecond", 0, 1.0f);
    }

    // Deals damage per click based on the "damagePerClick" variable
    public void Hit()
    {
        Damage(damagePerClick);
    }

    // Deals damage per second based on the "damagePerSecond" variable
    private void HitPerSecond()
    {
        Damage(damagePerSecond);
    }

    // Deals the damage to the monster and manage the monster respawn
    private void Damage(int damage)
    {
        monsterComponent.health -= damage;
        monsterComponent.ShowFloatingText(damage);

        if (monsterComponent.health > 0)
        {
            // Hit animation
            Debug.Log(level + " - " + damage + "/" + monsterComponent.health);
        }
        else
        {
            Destroy(monster, 0.3f);

            level += 1;

            monster = monsterSpawner.SpawnMob();
            monsterComponent = monster.GetComponent<Monster>();
        }
    }

    // Increase the amount of coins
    public void AddCoins(int amount)
    {
        coins += amount;
    }
}
