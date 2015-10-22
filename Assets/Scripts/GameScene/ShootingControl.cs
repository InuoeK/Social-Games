using UnityEngine;
using System.Collections;

public class ShootingControl : MonoBehaviour {

    public GameObject bullet;
    public GameObject UIControls;

    private ControlController cc;

	// Use this for initialization
	void Start () {
        cc = UIControls.GetComponent<ControlController>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
