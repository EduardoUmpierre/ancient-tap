using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    public GameObject FloatingTextPrefab;
    public GameObject healthBarPrefab;
    public int health = 999;
    public int maxHealth = 999;
    public int bossFactor;

    Hero hero;
    bool isBoss = false;
    bool isInvulnerable = true;
    GameObject healthBar;

    //
    void Awake()
    {
        isInvulnerable = true;
    }

    // Use this for initialization
    void Start() {
        hero = GameObject.Find("Hero").GetComponent<Hero>();

        isBoss = hero.GetLevel() % 5 == 0;
        maxHealth = health = hero.GetLevel() * (bossFactor * 5);

        healthBar = Instantiate(healthBarPrefab, new Vector3(0, isBoss ? 3.5f : 2.5f, 0), Quaternion.identity, transform);
        healthBar.GetComponent<SpriteRenderer>().sortingOrder = 1;

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

        Destroy(healthBar);
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

    //
    public bool IsInvulnerable()
    {
        return isInvulnerable;
    }
}
