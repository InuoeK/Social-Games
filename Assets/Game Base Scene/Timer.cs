using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    DateTime timeAtLastPause;
    bool rewardGiven;

    // Countdown time in seconds
    float countdownTimer;

    // Use this for initialization
    void Start()
    {
        rewardGiven = false;
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
    void Update()
    {
        Countdown();
        CheckIsTimeUp();
    }

    void GiveReward()
    {
        this.gameObject.GetComponent<TaskBox>().TaskFinished();
        rewardGiven = true;
    }

    void CheckIsTimeUp()
    {
        if (countdownTimer < 0.0f)
        {
            if (rewardGiven == false)
                GiveReward();
            // Do the rest of the cleanup here
        }

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
