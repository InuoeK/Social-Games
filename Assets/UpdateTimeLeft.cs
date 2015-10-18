using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateTimeLeft : MonoBehaviour {

	void UpdateText()
	{
		this.GetComponent<Text>().text = this.transform.parent.GetComponent<Timer> ().GetCountdownTime ().ToString();
	}
	// Update is called once per frame
	void Update () {
		UpdateText ();
	}
}
