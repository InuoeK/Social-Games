using UnityEngine;
using System.Collections;

public class Scavenge : MonoBehaviour {

	public SceneController sc;
	// Use this for initialization
	void Start () {
		sc = GameObject.Find ("SceneController").GetComponent<SceneController>();
	}
	
	public void ShowScavengeMenu()
	{
		sc.ShowScavengeMenu ();
	}

	public void HideScavengeMenu()
	{
		sc.HideScavengeMenu ();
	}
}
