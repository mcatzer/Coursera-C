using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    // Time to live to destroy bullets after some time has passed
    const float ttl = 2f;
    Timer DeathTimer;

    // Movement constants
    const float ImpulseForce = 4f;

    /// <summary>
    /// Bullet movement code
    /// </summary>
    public void ApplyForce(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().AddForce(direction * ImpulseForce, ForceMode2D.Impulse);
    }

	// Use this for initialization
	void Start ()
    {
        DeathTimer = gameObject.AddComponent<Timer>();
        DeathTimer.Duration = ttl;
        DeathTimer.Run();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (DeathTimer.Finished)
        {
            Destroy(gameObject);
        }
	}
}
