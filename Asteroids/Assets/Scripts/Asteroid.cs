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

    // random movement constants
    const float MinImpulseForce = 0.5f;
    const float MaxImpulseForce = 2f;

    /// <summary>
    /// Makes the asteroid fly in the given direction
    /// </summary>
    public void StartMoving( float angle )
    {
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(direction * magnitude, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Picks asteroid direction based on where it starts
    /// </summary>
    public void Initialize( Direction Dir, Vector3 Loc )
    {
        //set position
        gameObject.transform.position = Loc;

        // random movement code
        float angle = Random.Range(0, 30 * Mathf.Deg2Rad);

        switch (Dir)
        {
            case Direction.Right:
                angle -= 15 * Mathf.Deg2Rad;
                break;
            case Direction.Up:
                angle += 75 * Mathf.Deg2Rad;
                break;
            case Direction.Left:
                angle += 165 * Mathf.Deg2Rad;
                break;
            case Direction.Down:
                angle += 255 * Mathf.Deg2Rad;
                break;
            default:
                break;
        }
        

        StartMoving(angle);

    }

    // Use this for initialization
    void Start ()
    {

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

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    /// <summary>
    /// Destroy asteroids on collision with bullets
    /// </summary>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            AudioManager.Play(AudioClipName.AsteroidHit);
            Destroy(coll.gameObject);

            // if the asteroid isn't small enough - spawn 2 smaller asteroids first
            if (!(gameObject.transform.localScale.x < 0.5f ))
            {
                Vector3 newScale = gameObject.transform.localScale;
                newScale.x /= 2;
                newScale.y /= 2;
                gameObject.transform.localScale = newScale;
                gameObject.GetComponent<CircleCollider2D>().radius /= 2;


                GameObject Debree1 = Instantiate<GameObject>(gameObject);
                Debree1.GetComponent<Asteroid>().StartMoving(Random.Range(0, 2 * Mathf.PI));
                GameObject Debree2 = Instantiate<GameObject>(gameObject);
                Debree2.GetComponent<Asteroid>().StartMoving(Random.Range(0, 2 * Mathf.PI));
            }

            Destroy(gameObject);

        }
            

    }
}
