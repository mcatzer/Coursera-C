using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    [SerializeField]
    Text scoreText;

    bool TimerRunning = true;

    float timeElapsed = 0;

	// Use this for initialization
	void Start ()
    {
        scoreText.text = "0";
	}

    /// <summary>
    /// Stops game timer (score)
    /// </summary>
    public void stopGameTimer()
    {
        TimerRunning = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        timeElapsed += Time.deltaTime;
        if (TimerRunning)
        {
            scoreText.text = ((int)timeElapsed).ToString();
        }
    }
}
