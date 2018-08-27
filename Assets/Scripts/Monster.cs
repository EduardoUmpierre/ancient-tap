using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    public GameObject FloatingTextPrefab;
    public int health;
    public int maxHealth;
    public int bossFactor;

    Hero hero;
    bool isBoss = false;
    int factor = 1;

    // Use this for initialization
    void Start() {
        isBoss = Hero.level % 5 == 0;
        factor = isBoss ? bossFactor : factor;

        hero = GameObject.Find("Hero").GetComponent<Hero>();
        maxHealth = health = Hero.level * (factor * 5);
	}

    // Receives damage at every click
    void OnMouseDown() {
        hero.Hit();
    }

    // Increase the hero amount of coins after be destroyed
    private void OnDestroy()
    {
        hero.AddCoins(5 * (Hero.level * factor));
    }

    // Shows the Floating Text
    public void ShowFloatingText(int damage, bool isCriticalHit) {
        Color32 color;
        int fontSize = 30;

        if (isCriticalHit) {
            color = new Color32(218, 191, 0, 255); // Yellow
            fontSize = 40;
        } else {
            color = new Color32(218, 0, 0, 255); // Red
        }

        // Creates the floating text
        var floatingText = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        floatingText.GetComponent<TextMesh>().text = damage.ToString();
        floatingText.GetComponent<TextMesh>().color = color;
        floatingText.GetComponent<TextMesh>().fontSize = fontSize;
        floatingText.GetComponent<Renderer>().sortingOrder = 2;
    }
}
