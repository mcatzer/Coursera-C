using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    // Sprites
    [SerializeField]
    Sprite AsteroidSprite1;
    [SerializeField]
    Sprite AsteroidSprite2;
    [SerializeField]
    Sprite AsteroidSprite3;



    // Use this for initialization
    void Start () {

        // set a random sprite
        switch (Random.Range(0,2))
        {
            case 0:
                gameObject.GetComponent<SpriteRenderer>().sprite = AsteroidSprite1;
                break;
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = AsteroidSprite2;
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = AsteroidSprite3;
                break;
            default:
                break;
        }

        // random movement constants
        const float MinImpulseForce = 3f;
        const float MaxImpulseForce = 5f;

        // random movement code
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce( direction * magnitude, ForceMode2D.Impulse);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
