using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public struct Task
{
    public string type;
    public string location;
    public float timeRequired;
}

public class TaskManager : MonoBehaviour {
    VerticalLayoutGroup vlg;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddTask(Task a_task)
    {
		GameObject newTask = Instantiate (Resources.Load ("TaskBox")) as GameObject;

        newTask.transform.parent = GameObject.Find("TaskHolder").transform;
        newTask.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        newTask.GetComponent<TaskBox>().SetTask(a_task);

        newTask.GetComponent<TaskBox>().InitializeTaskBox();
    }
 
    
}
