﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterSpawner : MonoBehaviour {
    public GameObject[] bossPrefab;
    public GameObject[] minionPrefab;
    public GameObject healthBar;

    // Called first
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
    }

    // Called when the game is terminated
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //
    private void Start()
    {
        SpawnMob();
    }

    // Instantiate a new monster based on level
    public GameObject SpawnMob()
    {
        GameObject monster = Instantiate(Hero.level % 5 == 0 ? bossPrefab[Random.Range(0, bossPrefab.Length)] : minionPrefab[Random.Range(0, minionPrefab.Length)], new Vector3(0, 1.15f, 0), Quaternion.identity, transform);
        monster.GetComponent<SpriteRenderer>().sortingOrder = -1;

        healthBar.GetComponent<HealthBar>().SetMonster(monster.GetComponent<Monster>());

        return monster;
    }
}
