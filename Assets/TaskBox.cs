using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TaskBox : MonoBehaviour
{
    Task thisTask;
    public GameObject AcceptButton;

    

    // Use this for initialization
    void Start()
    {
        AcceptButton.SetActive(false);
        transform.parent = GameObject.Find("TaskHolder").transform;
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        this.GetComponentInChildren<Timer>().SetCountdownTimer(thisTask.timeRequired);
        this.GetComponentInChildren<Text>().text = thisTask.type + " " + thisTask.location;
    }


    public void SetTask(Task a_task)
    {
        thisTask = a_task;
    }


    public void TaskFinished()
    {
        Destroy(transform.Find("TimeLeft"));
        transform.Find("TaskText").GetComponent<Text>().text =
        thisTask.type + " " + thisTask.location + " completed!" + "\n" +
        thisTask.rewardValue + " " + thisTask.rewardType + " ready for pick up.";
        AcceptButton.SetActive(true);
    }

    public void GenerateReward()
    {
        if (GameObject.Find("Player").GetComponent<BaseAttributesAndCommands>().CheckIfMaxResources() ||
            GameObject.Find("Player").GetComponent<BaseAttributesAndCommands>().CheckIfMaxFood())
        {
            transform.Find("TaskText").GetComponent<Text>().text = "Your storage is too full to accept " + thisTask.rewardValue + " " + thisTask.rewardType;
            return;
        }
        GameObject.Find("SceneController").GetComponent<RewardGenerator>().GenerateReward(thisTask.rewardValue, thisTask.rewardType);
        Destroy(this.gameObject);
    }

}
