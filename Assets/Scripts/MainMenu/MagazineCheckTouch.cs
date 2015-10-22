using UnityEngine;
using System.Collections;


public class MagazineCheckTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
 
	}

    public bool CheckTouchMagazine()
    {
        PublicTouchFunctions p = new PublicTouchFunctions();
        return p.CheckTouchObject("Magazine");
    }

    public bool CheckTouchMagazineBottom()
    {
        PublicTouchFunctions p = new PublicTouchFunctions();
        return p.CheckTouchObject("MagazineBottom");
    }
}
