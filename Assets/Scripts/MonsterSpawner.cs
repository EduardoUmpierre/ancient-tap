using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterSpawner : MonoBehaviour {
    public GameObject boss;
    public GameObject minion;

	// Called zero
    void Awake()
    {
        SpawnMob();

        // Loads the game
        // SaveLoad.Load();
    }

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

    void OnApplicationQuit() 
    {
        SaveLoad.Save();
    }

    // Instantiate a new monster based on level
    public GameObject SpawnMob() {
        GameObject monster = Instantiate(Hero.level % 5 == 0 ? boss : minion, new Vector3(0, 1.15f, 0), Quaternion.identity, transform);
        monster.GetComponent<SpriteRenderer>().sortingOrder = 1;

        return monster;
    }
}
