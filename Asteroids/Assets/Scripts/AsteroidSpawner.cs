using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    [SerializeField]
    GameObject AsteroidPrefab;

    /// <summary>
    /// Spawm am asteroid
    /// </summary>
    void CreateAsteroid(Direction dir, float locX, float locY)
    {

        GameObject AsteroidObj = Instantiate<GameObject>(AsteroidPrefab);
        Asteroid AsteroidScript = AsteroidObj.GetComponent<Asteroid>();

        Vector3 AstLoc = new Vector3( locX, locY );
        AsteroidScript.Initialize( dir, AstLoc );

    }

	// Use this for initialization
	void Start ()
    {
        //create asteroids
        float asteriodRad = AsteroidPrefab.GetComponent<CircleCollider2D>().radius;

        CreateAsteroid(Direction.Right, ScreenUtils.ScreenLeft + asteriodRad, 0);
        CreateAsteroid(Direction.Left, ScreenUtils.ScreenRight - asteriodRad, 0);
        CreateAsteroid(Direction.Up, 0, ScreenUtils.ScreenBottom + asteriodRad);
        CreateAsteroid(Direction.Down, 0, ScreenUtils.ScreenTop - asteriodRad);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
