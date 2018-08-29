using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    public GameObject FloatingTextPrefab;
    public int health = 999;
    public int maxHealth = 999;
    public int bossFactor;
    public string enemyName;

    Hero hero;
    bool isInvulnerable;

    // Turns the monster invulnerable
    void Awake()
    {
        isInvulnerable = true;
    }

    // Use this for initialization
    void Start() {
        hero = GameObject.Find("Hero").GetComponent<Hero>();

        maxHealth = health = hero.GetLevel() * (bossFactor * 5);

        isInvulnerable = false;
    }

    // Receives damage at every click
    private void OnMouseDown()
    {
        hero.Hit();
    }

    // Increase the hero amount of coins after be destroyed
    private void OnDestroy()
    {
        hero.AddCoins(5 * (Hero.level * bossFactor));
        // @todo Coins drop
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

    // Returns the invulnerable status
    public bool IsInvulnerable()
    {
        return isInvulnerable;
    }
}
