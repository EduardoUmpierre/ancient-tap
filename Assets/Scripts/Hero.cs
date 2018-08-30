using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
    public static int level = 1;
    public static int maxLevel;
    public static float coins = 0;
    public static float damagePerSecond = 0;
    public static float damagePerClick = 1;
    public static float criticalChance = 0f;
    public static float criticalDamage = 2f;
    public static float goldBonus = 1f;

    public MonsterSpawner monsterSpawner;
    public GameObject ExplosionPrefab;

    Monster monsterComponent;
    GameObject monster;

    // Use this for initialization
    void Start() {
        monster = GameObject.FindGameObjectsWithTag("Enemy")[0];
        monsterComponent = monster.GetComponent<Monster>();

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
    private void Damage(float damage)
    {
        if (damage > 0 && !monsterComponent.IsInvulnerable())
        {
            bool isCriticalHit = Random.Range(0f, 1f) > (100 - criticalChance) / 100;

            damage *= isCriticalHit ? Mathf.CeilToInt(criticalDamage) : 1;

            monsterComponent.health -= damage;
            monsterComponent.ShowFloatingText(damage, isCriticalHit);

            if (monsterComponent.health > 0)
            {
                // Hit animation
            }
            else
            {
                // Updates the hero's level
                level += 1;
                maxLevel = level > maxLevel ? level : maxLevel;

                DestroyMonster();
            }
        }
    }

    // Increase the amount of coins
    public void AddCoins(float amount)
    {
        coins += Mathf.CeilToInt(amount * goldBonus);
    }

    // Upgrades the hero status
    public bool Upgrade(string type, float amount, float cost)
    {
        if (!CanUpgrade(cost))
        {
            return false;
        }

        switch (type)
        {
            case "dps":
                IncreaseDamagePerSecond(amount);
                break;
            case "dpc":
                IncreaseDamagePerClick(amount);
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

    // Verifies if the hero has the necessary coins amount to do the upgrade
    private bool CanUpgrade(float cost)
    {
        return coins >= cost;
    }

    //
    private void IncreaseDamagePerSecond(float amount) 
    {
        damagePerSecond += amount;
    }

    //
    private void IncreaseDamagePerClick(float amount) 
    {
        damagePerClick += amount;
    }

    //
    private void IncreaseCriticalChance(float amount)
    {
        criticalChance += amount;
    }

    //
    private void IncreaseCriticalDamage(float amount)
    {
        criticalDamage += amount;
    }

    //
    private void IncreaseGoldBonus(float amount)
    {
        goldBonus += amount;
    }

    //
    public float GetDamagePerSecond()
    {
        return damagePerSecond;
    }

    //
    public float GetDamagePerClick()
    {
        return damagePerClick;
    }

    //
    public float GetCriticalChance()
    {
        return criticalChance;
    }

    //
    public float GetCriticalDamage()
    {
        return criticalDamage;
    }

    //
    public float GetGoldBonus()
    {
        return goldBonus;
    }

    //
    public int GetLevel()
    {
        return level;
    }

    //
    public void DestroyMonster()
    {
        // Explosion animation
        GameObject explosion = Instantiate(ExplosionPrefab, new Vector3(0, 0.6f, 0), transform.rotation, GameObject.Find("Spawner").transform);
        Destroy(explosion, 0.5f);

        // Destroys the monster
        Destroy(monster);

        // Spawns a new monster
        monster = monsterSpawner.SpawnMob();
        monsterComponent = monster.GetComponent<Monster>();
    }
}
