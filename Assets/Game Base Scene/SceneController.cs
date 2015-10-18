using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

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
}
