using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour {
    public float destroyTime = 0.4f;
    public Vector3 offset = new Vector3(0, 0.5f, 0);
    public Vector3 randomizeIntensity = new Vector3(0.5f, 0, 0);

	// Use this for initialization
	void Start () {
		Destroy(gameObject, destroyTime);

        float randomX = Random.Range(-randomizeIntensity.x, randomizeIntensity.x);
        float randomY = Random.Range(-randomizeIntensity.y, randomizeIntensity.y);
        float randomZ = Random.Range(-randomizeIntensity.z, randomizeIntensity.z);

        transform.localPosition += offset;
        transform.localPosition += new Vector3(randomX, randomY, randomZ);
	}
}
