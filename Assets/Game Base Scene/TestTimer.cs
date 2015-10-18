using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TestTimer : MonoBehaviour {

    bool paused;
    GameObject text;
    private float countdown;

    DateTime timeAtPause;
    

	// Use this for initialization
	void Start () {
        countdown = 10.0f;
        text = GameObject.Find("TestText");
	}
	
	// Update is called once per frame
	void Update () {
            
        text.GetComponent<Text>().text = countdown.ToString();
        countdown -= Time.deltaTime;
	    
	}


    float CalculateTimeBetweenPause()
    {
        return (float)(DateTime.Now - timeAtPause).TotalSeconds;
    }


    void OnApplicationPause(bool pausedStatus)
    {
        if(pausedStatus)
        timeAtPause = DateTime.Now;
    }

    void OnApplicationFocus(bool runningStatus)
    {
        if (runningStatus)
        {
            countdown -= CalculateTimeBetweenPause();
        }
    }
}
