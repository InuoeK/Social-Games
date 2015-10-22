using UnityEngine;
using System.Collections;

public class ControlModule : MonoBehaviour
{

    JoystickScripts mJoy;
    JoystickScripts aJoy;

    // Use this for initialization
    void Start()
    {
        mJoy = GameObject.Find("MovementJoy").GetComponent<JoystickScripts>();
        aJoy = GameObject.Find("AimingJoy").GetComponent<JoystickScripts>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    /*##########################################
     *  PUBLICS
     * 
     *##########################################
     */

    public Vector2 getAimingDirectionVec() { return aJoy.getDirectionVector(aJoy.gameObject.transform.position); }
    public Vector2 getMovementDirectionVec() { return mJoy.getDirectionVector(mJoy.gameObject.transform.position); }
    public bool IsAimingJoyActive() { return aJoy.GetIsActive(); }
    public bool IsMovementJoyActive() { return mJoy.GetIsActive(); }
}
