using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public struct Task
{
    public string type;
    public string location;
    public float timeRequired;

    public string rewardType;
    public float rewardValue;
}

public class TaskManager : MonoBehaviour {

    public void CreateScavengeTask(string a_location)
    {
        Task tempTask = new Task();
        tempTask.type = "Scavenge";
        tempTask.location = a_location;
        tempTask.timeRequired = 2.0f; // change this depending on the location

        if (a_location == "Cafeteria")
        {
            tempTask.rewardType = "Food";
            tempTask.rewardValue = 2;
        }
        if (a_location == "Janitor's Room")
        {
            tempTask.rewardType = "Resources";
            tempTask.rewardValue = 25;
        }    
        AddTask(tempTask);
    }

    public void CreateBuildTask()
    {
        //todo
    }

    public void AddTask(Task a_task)
    {
		GameObject newTask = Instantiate (Resources.Load ("TaskBox")) as GameObject;
        newTask.GetComponent<TaskBox>().SetTask(a_task);

    }
 
    
}
