using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour {
    // Rock prefab
    [SerializeField]
    GameObject RockPrefab;

    // Rock sprites
    [SerializeField]
    Sprite RockSprite0;
    [SerializeField]
    Sprite RockSprite1;
    [SerializeField]
    Sprite RockSprite2;

    Timer timer;

	// Use this for initialization
	void Start () {

        // Add timer to spawn rocks every second
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 1;
        timer.Run();
		
	}
	
	// Update is called once per frame
	void Update () {

        // Check the timer
        if (timer.Finished)
        {
            //Check how many rocks there are, if < 3 then spawn a new one
            if (GameObject.FindGameObjectsWithTag("Rock").Length < 3)
            {
                // Spawn a new rock from prefab
                GameObject rock = Instantiate<GameObject>(RockPrefab);
                SpriteRenderer rockSpriteRenderer = rock.GetComponent<SpriteRenderer>();

                // Assign a random sprite to our new rock
                int spriteNumber = Random.Range(0, 3);
                switch (spriteNumber)
                {
                    case 0:
                        rockSpriteRenderer.sprite = RockSprite0;
                        break;
                    case 1:
                        rockSpriteRenderer.sprite = RockSprite1;
                        break;
                    case 2:
                        rockSpriteRenderer.sprite = RockSprite2;
                        break;
                    default:
                        break;
                }

                // Restart the timer
                timer.Run();
            }
        }
		
	}
}
