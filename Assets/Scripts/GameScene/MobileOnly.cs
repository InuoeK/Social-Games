using UnityEngine;
using System.Collections;

public class MobileOnly : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (Application.platform != RuntimePlatform.Android || Application.platform != RuntimePlatform.IPhonePlayer)
			this.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
