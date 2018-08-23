using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    Hero hero;
    public GameObject FloatingTextPrefab;
    public int health;
    public int maxHealth;

	// Use this for initialization
	void Start () {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        maxHealth = health = Hero.level * ((Hero.level % 5 == 0 ? 10 : 1) * 5);
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnMouseDown() {
        hero.hit();
    }

    // Shows the Floating Text
    public void showFloatingText(int damage) {
        if (FloatingTextPrefab) {
            Color32 color;

            if (damage < 100) {
                // Green
                color = new Color32(28, 199, 48, 255);
            } else if (damage < 1000) {
                // Yellow
                color = new Color32(218, 191, 0, 255);
            } else {
                // Red
                color = new Color32(218, 0, 0, 255);
            }

            var floatingText = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
            floatingText.GetComponent<TextMesh>().text = Hero.damagePerClick.ToString();
            floatingText.GetComponent<TextMesh>().color = color;
            floatingText.GetComponent<Renderer>().sortingOrder = 2;
        }
    }
}
