using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	public GameObject TaskManager;
	public GameObject ScavengeMenu;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowScavengeMenu()
	{
		ScavengeMenu.SetActive (true);
	}

	public void HideScavengeMenu()
	{
		ScavengeMenu.SetActive (false);
	}

	public void CreateScavengeTask(string a_location)
	{
		Task tempTask = new Task ();
		tempTask.type = "Scavenge";
		tempTask.location = a_location;
		tempTask.timeRequired = 10.0f;

		TaskManager.GetComponent<TaskManager> ().AddTask (tempTask);
	}
}
