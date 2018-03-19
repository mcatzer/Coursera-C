using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    float turnrate;

	// Use this for initialization
	void Start ()
    {

        // Copypasted movement code! Slightly more max force
        const float MinImpulseForce = 1f;
        const float MaxImpulseForce = 3f;
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            direction * magnitude,
            ForceMode2D.Impulse);

        // Random turnrate to make the rock rotate as it flies
        turnrate = Random.Range(-10, 10);

    }
	
	// Update is called once per frame
	void Update ()
    {

        // Let's make the rock rotate as it flies
        // Not necessary for the assignment, just for fun
        gameObject.transform.Rotate(0, 0, turnrate);

	}

    void OnBecameInvisible()
    {

        // If the rock can't be seen - destroy it
        Destroy(gameObject);

    }
}
