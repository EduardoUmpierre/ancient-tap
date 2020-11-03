using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
  public GameObject ExplosionPrefab;
  public GameObject AdContainerPrefab;
  public int maxLaps = 10;

  Vector3 from;
  Vector3 to;
  SpriteRenderer sprite;
  int laps = 0;
  bool isDisabled;
  bool isMovingLeft;

  // Use this for initialization
  void Start()
  {
    isDisabled = false;
    isMovingLeft = true;
    sprite = gameObject.GetComponent<SpriteRenderer>();
    from = new Vector3(-2.5f, transform.position.y);
    to = new Vector3(2.5f, transform.position.y);
  }

  // Update is called once per frame
  void Update()
  {
    if (laps < maxLaps)
    {
      // Inverts the fly direction if it hits camera border
      if (transform.position == to)
      {
        isMovingLeft = true;
        sprite.flipX = false;
      }
      else if (transform.position == from)
      {
        isMovingLeft = false;
        sprite.flipX = true;
      }

      if (transform.position == to || transform.position == from)
      {
        laps++;
      }
    }
    else
    {
      if (!isDisabled)
      {
        isDisabled = true;

        // Explosion animation
        GameObject explosion = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 0.5f);

        Destroy(gameObject);
      }
    }

    if (!isDisabled)
    {
      transform.position = Vector3.MoveTowards(transform.position, isMovingLeft ? from : to, 1f * Time.deltaTime);
    }
  }

  //
  void OnMouseDown()
  {
    Instantiate(AdContainerPrefab, new Vector3(0, 1.5f, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
    Destroy(gameObject);
  }
}
