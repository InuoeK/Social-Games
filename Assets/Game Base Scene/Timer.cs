using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	DateTime timeAtLastPause;

	// Countdown time in seconds
	float countdownTimer;

	// Use this for initialization
	void Start () {

	}

	public void SetCountdownTimer(float a_time)
	{
		countdownTimer = a_time;
	}

	public float GetCountdownTime()
	{
		return countdownTimer;
	}
	// Update is called once per frame
	void Update () {
		Countdown ();
		CheckIsTimeUp ();
	}


	void CheckIsTimeUp()
	{
		if (countdownTimer < 0.0f) 
		{
			this.GetComponentInChildren<Text>().text = "Finished!";

			// Do the rest of the cleanup here
		}

		if (countdownTimer < -5.0f)
			Destroy (this.gameObject);
	}

	void Countdown()
	{
		countdownTimer -= Time.deltaTime;
	}

	void OnApplicationPause(bool pauseStatus)
	{
		timeAtLastPause = DateTime.Now;
	}

	void OnAppplicationFocus(bool isFocus)
	{
		if (isFocus) 
		{
			float timeSubtract = CalculateTimeDifferenceFromLastPause();
			countdownTimer -= timeSubtract;
		}
	}

	float CalculateTimeDifferenceFromLastPause()
	{
		return (float)(DateTime.Now - timeAtLastPause).TotalSeconds;
	}
}
