using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour {

    // screen wrap variables
    float colliderRadius;

    // Use this for initialization
    void Start () {

        colliderRadius = GetComponent<CircleCollider2D>().radius;

    }

    /// <summary>
    /// Screen wrapping when the ship leaves the screen
    /// </summary>
    void OnBecameInvisible()
    {

        Vector2 position = transform.position;

        // Check left & right
        if (position.x + colliderRadius < ScreenUtils.ScreenLeft ||
            position.x - colliderRadius > ScreenUtils.ScreenRight)
        {
            position.x *= -1;
        }

        // Check top & bottom
        if (position.y - colliderRadius > ScreenUtils.ScreenTop ||
            position.y + colliderRadius < ScreenUtils.ScreenBottom)
        {
            position.y *= -1;
        }

        // Move the ship
        transform.position = position;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
