using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterSpawner : MonoBehaviour {
    public GameObject boss;
    public GameObject minion;
    GameObject spawn;

	// called zero
    void Awake()
    {
        spawn = spawnMob();
    }

    // called first
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
    }

    // called third
    void Start()
    {
    }

    // called when the game is terminated
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Instantiate a new monster based on level
    public GameObject spawnMob() {
        GameObject monster = Instantiate(Hero.level % 5 == 0 ? boss : minion, new Vector3(0, 1.15f, 0), Quaternion.identity, transform);
        monster.GetComponent<SpriteRenderer>().sortingOrder = 1;

        return monster;
    }
}
