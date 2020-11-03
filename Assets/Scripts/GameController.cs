using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public float flySpawnDelay;
    public GameObject FlyPrefab;

    // Called zero
    void Awake()
    {
        // Loads the game
        SaveLoad.Load();
    }

    // Use this for initialization
    void Start ()
    {
        // Invokes the fly
        InvokeRepeating("SpawnFly", 0, flySpawnDelay);
    }

    // Saves the game state when quitting the application
    void OnApplicationQuit()
    {
        SaveLoad.Save();
    }

    // Saves the game state when pausing the application
    void OnApplicationPause(bool pause)
    {
        SaveLoad.Save();
    }

    // Spawns a fly
    private void SpawnFly()
    {
        if (GameObject.FindGameObjectWithTag("Fly") == null)
        {
            bool comingByLeft = false;
            float horizontalPlacement = 4f;

            if (Random.value < 0.5f)
            {
                comingByLeft = true;
                horizontalPlacement = -4f;
            }

            GameObject fly = Instantiate(FlyPrefab, new Vector3(horizontalPlacement, 3.5f, 0), Quaternion.identity, transform.parent);
            fly.GetComponent<SpriteRenderer>().flipX = comingByLeft;
        }
    }
}
