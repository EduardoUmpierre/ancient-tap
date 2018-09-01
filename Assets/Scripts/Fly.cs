using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour {
    public GameObject AdContainerPrefab;

    Vector3 from;
    Vector3 to;
    SpriteRenderer sprite;
    bool isMovingLeft;

    // Use this for initialization
    void Start ()
    {
        isMovingLeft = true;
        sprite = gameObject.GetComponent<SpriteRenderer>();
        from = new Vector3(-2.5f, transform.position.y);
        to = new Vector3(2.5f, transform.position.y);
    }
	
    // Update is called once per frame
    void Update ()
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

        transform.position = Vector3.MoveTowards(transform.position, isMovingLeft ? from : to, 1f * Time.deltaTime);
    }

    //
    void OnMouseDown()
    {
        Instantiate(AdContainerPrefab, new Vector3(0, 1.5f, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
        Destroy(gameObject);
    }
}
