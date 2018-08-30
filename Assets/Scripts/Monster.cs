using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    public GameObject FloatingTextPrefab;
    public GameObject BossTimerPrefab;
    public float health = 999;
    public float maxHealth = 999;
    public int bossFactor;
    public string enemyName;

    Hero hero;
    GameObject bossTimer;
    bool isInvulnerable;
    bool isBoss;

    // Turns the monster invulnerable
    void Awake()
    {
        isInvulnerable = true;
    }

    // Use this for initialization
    void Start() {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        isBoss = hero.GetLevel() % 5 == 0;

        maxHealth = health = hero.GetLevel() * (bossFactor * 5);

        isInvulnerable = false;

        if (isBoss)
        {
            bossTimer = Instantiate(BossTimerPrefab, new Vector3(0, 0.65f, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
        }
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

        if (isBoss)
        {
            Destroy(bossTimer);
        }
    }

    // Shows the Floating Text
    public void ShowFloatingText(float damage, bool isCriticalHit) {
        Color32 color;
        int fontSize = 30;

        if (isCriticalHit) {
            color = new Color32(228, 200, 0, 255); // Yellow
            fontSize = 40;
        } else {
            color = new Color32(190, 0, 0, 255); // Red
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
