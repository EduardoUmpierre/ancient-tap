using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour {
    public GameObject BossFightButtonPrefab;
    public GameObject HUDContainer;
    public GameObject HUDLevel;
    public GameObject HUDCoins;
    public GameObject HeroObject;

    GameObject bossFightButton;
    Hero hero;

	// Use this for initialization
	void Start() {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        hero = HeroObject.GetComponent<Hero>();

        if (Hero.maxLevel > Hero.level)
        {
            SpawnBossFightButton();
        }
    }
	
	// Update is called once per frame
	void Update() {
        HUDLevel.GetComponent<Text>().text = "Level " + Hero.level;
        HUDCoins.GetComponent<Text>().text = "$ " + Hero.coins.ToString();
    }

    //
    public void SpawnBossFightButton()
    {
        bossFightButton = Instantiate(BossFightButtonPrefab, new Vector3(2.08f, 4.1f, 0), Quaternion.identity, HUDContainer.transform);
        bossFightButton.GetComponent<Button>().onClick.AddListener(() => BossFightButtonClick());
    }

    //
    void BossFightButtonClick()
    {
        Hero.level += 1;
        hero.DestroyMonster();
        Destroy(bossFightButton);
    }
}
