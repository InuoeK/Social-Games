using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TaskBox : MonoBehaviour
{

    string rewardType;
    float rewardAmount;
    Task thisTask;
    GameObject SceneController;
    public GameObject AcceptButton;
    public GameObject PlayerStats;

    // Use this for initialization
    void Start()
    {
        AcceptButton.SetActive(false);
        SceneController = GameObject.Find("SceneController");
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetTask(Task a_task)
    {
        thisTask = a_task;
    }

    public void InitializeTaskBox()
    {
        this.GetComponentInChildren<Text>().text = thisTask.type + " " + thisTask.location;
        this.GetComponentInChildren<Timer>().SetCountdownTimer(thisTask.timeRequired);
    }

    public void TaskFinished()
    {
        Destroy(transform.Find("TimeLeft"));

        Debug.Log(thisTask.location + thisTask.type);
        rewardAmount = 0;
        rewardType = " ";

        if (thisTask.type == "Scavenge")
        {
            if (thisTask.location == "Cafeteria")
            {
                rewardAmount = 2;
                rewardType = "Food";
            }
            else if (thisTask.location == "Janitor's Room")
            {
                rewardAmount = 25;
                rewardType = "Resources";
            }
        }

        transform.Find("TaskText").GetComponent<Text>().text =
        thisTask.type + " " + thisTask.location + " completed!" + "\n" +
        rewardAmount + " " + rewardType + " ready for pick up.";

        AcceptButton.SetActive(true);
    }

    public void GenerateReward()
    {

        if (GameObject.Find("Player").GetComponent<BaseAttributesAndCommands>().CheckIfMaxResources() ||
       GameObject.Find("Player").GetComponent<BaseAttributesAndCommands>().CheckIfMaxFood())
            return;


        SceneController.GetComponent<RewardGenerator>().GenerateReward(rewardAmount, rewardType);
        Destroy(this.gameObject);
    }

}
