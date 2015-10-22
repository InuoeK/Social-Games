using UnityEngine;
using System.Collections;

public class JoystickScripts : MonoBehaviour
{

    RuntimePlatform pf;
    GameObject Joystick;
    GameObject JoystickBoundary;

    private Vector2 resetPosition;
    private float boundaryRadius;
    private Touch stickTouch;
    public string boundaryName;
    float sizeMult;
    bool isActive;

    // First value = min, second value = max
    // Based off screen length percentage
    public float[] touchLimitPercent;

    // Actual x boundary for touches to register to Joystick
    float[] touchPosLimit = new float[2];


    // Use this for initialization
    void Start()
    {
        sizeMult = 250.0f;
        Joystick = this.gameObject;
        JoystickBoundary = GameObject.Find(boundaryName);
        setResetPos();
        boundaryRadius = JoystickBoundary.GetComponent<CircleCollider2D>().radius * 2;
        touchPosLimit[0] = Screen.width * touchLimitPercent[0];
        touchPosLimit[1] = Screen.width * touchLimitPercent[1];
        pf = Application.platform;
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkInputMobile();
        getDirectionVector(Joystick.transform.position);
    }

    private void setResetPos()
    {
        resetPosition = Joystick.transform.position;
    }

    private void checkInputMobile()
    {
        if (setTouchToStick())
            updateJoyPosition();
        else
            resetJoystick();
    }


    private bool setTouchToStick()
    {
        foreach (Touch t in Input.touches)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(t.position);
            Vector2 tPos = new Vector2(wp.x, wp.y);
            Collider2D hit = Physics2D.OverlapPoint(t.position);
            if (hit && hit.gameObject.name == boundaryName)
            {
                JoystickBoundary.GetComponent<CircleCollider2D>().radius = sizeMult;
                stickTouch = t;
                isActive = true;
                return true;
            }
        }
        isActive = false;
        return false;
    }

    private void updateJoyPosition()
    {
        if (stickTouch.phase != TouchPhase.Ended)
        {
            if (Vector2.Distance(stickTouch.position, resetPosition) > boundaryRadius)
            {
                Vector2 t = stickTouch.position - (getDirectionVector(stickTouch.position) * boundaryRadius);
                Joystick.transform.position = resetPosition + (stickTouch.position - t);
            }
            else { Joystick.transform.position = stickTouch.position; }
        }
    }

    private void resetJoystick()
    {
        Joystick.transform.position = resetPosition;
        JoystickBoundary.GetComponent<CircleCollider2D>().radius = boundaryRadius / 2;
    }

    public Vector2 getDirectionVector(Vector2 a_pos)
    {
        Vector2 t = new Vector2(Joystick.transform.position.x, Joystick.transform.position.y);
        if (t == resetPosition) { return Vector2.zero; }

        Vector2 retVec = a_pos - resetPosition;
        retVec.Normalize();
//        Debug.Log(retVec);
        return retVec;
    }

    public bool GetIsActive()
    {
        return isActive;
    }
}
