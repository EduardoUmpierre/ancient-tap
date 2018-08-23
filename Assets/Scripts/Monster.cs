using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    public GameObject FloatingTextPrefab;
    public int health;
    public int maxHealth;

    Hero hero;

    // Use this for initialization
    void Start () {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        maxHealth = health = Hero.level * ((Hero.level % 5 == 0 ? 5 : 1) * 5);
	}
	
	// Update is called once per frame
	void Update () {

	}

    // Receives damage at every click
    void OnMouseDown() {
        hero.Hit();
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

            // Creates the floating text
            var floatingText = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
            floatingText.GetComponent<TextMesh>().text = Hero.damagePerClick.ToString();
            floatingText.GetComponent<TextMesh>().color = color;
            floatingText.GetComponent<Renderer>().sortingOrder = 2;
        }
    }
}
