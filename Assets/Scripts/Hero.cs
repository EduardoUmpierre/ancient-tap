using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
    public static int level = 1;
    public static int damagePerClick = 1;
    public static int damagePerSecond = 0;

    MonsterSpawner monsterSpawner;
    Monster monsterComponent;
    GameObject monster;

	// Use this for initialization
	void Start () {
        monster = GameObject.FindGameObjectsWithTag("Enemy")[0];
        monsterComponent = monster.GetComponent<Monster>();
		monsterSpawner = GameObject.Find("Spawner").GetComponent<MonsterSpawner>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // 
    public void hit() {
        monsterComponent.health -= damagePerClick;
        monsterComponent.showFloatingText(damagePerClick);

        if (monsterComponent.health > 0) {
            Debug.Log(level + " - " + damagePerClick + "/" + monsterComponent.health);
        } else {
            Destroy(monster, 0.3f);

            level += 1;

            monster = monsterSpawner.spawnMob();
            monsterComponent = monster.GetComponent<Monster>();
        }
    }
}
