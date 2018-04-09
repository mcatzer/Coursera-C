using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Asteroids-like ship
/// </summary>
public class Ship : MonoBehaviour {

    [SerializeField]
    GameObject BulletPrefab;

    [SerializeField]
    Canvas UIref;

    // thrust and rotation variables
    Rigidbody2D rigb;
    Vector2 thrustDirection = new Vector2(1, 0);

    const float ThrustForce = 10;
    const float RotateDPS = 180;



    // Use this for initialization
    void Start () {

        rigb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {

        // rotation with changing thrust direction
        float rotationInput = Input.GetAxis("Rotate");
        if (rotationInput != 0)
        {

            float rotationAmnt = RotateDPS * Time.deltaTime;

            if (rotationInput < 0)
            {
                rotationAmnt *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmnt);

            float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(zRotation);
            thrustDirection.y = Mathf.Sin(zRotation);

        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameObject BulletObj = Instantiate<GameObject>(BulletPrefab);
            BulletObj.transform.SetPositionAndRotation(gameObject.transform.position, gameObject.transform.rotation);
            BulletObj.GetComponent<Bullet>().ApplyForce(thrustDirection);

            AudioManager.Play(AudioClipName.PlayerShot);
        }

    }

    /// <summary>
    /// FixedUpdate where we add thrust if space is pressed
    /// </summary>
    void FixedUpdate()
    {

        if (Input.GetAxis("Thrust") != 0)
        {
            rigb.AddForce(ThrustForce * thrustDirection, ForceMode2D.Force);
        }

    }

    /// <summary>
    /// OnCollisionEnter2D where we explode 
    /// if the ship collides with an asteriod
    /// </summary>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Asteroid")
        {
            UIref.GetComponent<HUD>().stopGameTimer();
            AudioManager.Play(AudioClipName.PlayerDeath);
            Destroy(gameObject);
        }
            
    }


}
