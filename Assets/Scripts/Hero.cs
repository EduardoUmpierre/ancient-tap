using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
    public static int level = 1;
    public static int coins = 0;

    MonsterSpawner monsterSpawner;
    Monster monsterComponent;
    GameObject monster;

    int damagePerSecond = 1;
    int damagePerClick = 1;
    float criticalChance = 0f;
    float criticalDamage = 2f;
    float goldBonus = 1f;

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
        bool isCriticalHit = Random.Range(0f, 1f) > (100 - criticalChance) / 100;

        damage *= isCriticalHit ? Mathf.CeilToInt(criticalDamage) : 1;

        monsterComponent.health -= damage;
        monsterComponent.ShowFloatingText(damage, isCriticalHit);

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
        coins += Mathf.CeilToInt(amount * goldBonus);
    }

    // Upgrades the hero status
    public bool Upgrade(string type, float amount, int cost)
    {
        if (CanUpgrade(cost))
        {
            switch (type)
            {
                case "dps":
                    IncreaseDamagePerSecond((int) amount);
                    break;
                case "dpc":
                    IncreaseDamagePerClick((int) amount);
                    break;
                case "crit_chance":
                    IncreaseCriticalChance(amount);
                    break;
                case "crit_damage":
                    IncreaseCriticalDamage(amount);
                    break;
                case "gold_bonus":
                    IncreaseGoldBonus(amount);
                    break;
            }

            coins -= cost;

            return true;
        }

        return false;
    }

    // Verifies if the hero has the necessary coins amount to do the upgrade
    private bool CanUpgrade(int cost)
    {
        return coins >= cost;
    }

    //
    private void IncreaseDamagePerSecond(int amount) 
    {
        damagePerSecond += amount;
    }

    //
    private void IncreaseDamagePerClick(int amount) 
    {
        damagePerClick += amount;
    }

    //
    private void IncreaseCriticalChance(float amount)
    {
        criticalChance *= amount;
    }

    //
    private void IncreaseCriticalDamage(float amount)
    {
        criticalDamage *= amount;
    }

    //
    private void IncreaseGoldBonus(float amount)
    {
        goldBonus *= amount;
    }
}
