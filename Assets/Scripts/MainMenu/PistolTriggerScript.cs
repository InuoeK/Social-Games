using UnityEngine;
using System.Collections;

public class PistolTriggerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool CheckTouchTrigger()
    {
        PublicTouchFunctions p = new PublicTouchFunctions();
        return p.CheckTouchObject("Trigger");
    }
}
