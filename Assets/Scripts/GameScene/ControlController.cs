using UnityEngine;
using System.Collections;

public class ControlController : MonoBehaviour
{
    public GameObject aimingJoy;
    public GameObject movementJoy;
    private int fingerID;
    private float boundaryRadius;

    public Vector2[] resetPosition = new Vector2[2];

    private bool[] isIdle = new bool[2];

    // Use this for initialization
    void Start()
    {

        resetPosition[0] = movementJoy.transform.position;
        resetPosition[1] = aimingJoy.transform.position;

        boundaryRadius = movementJoy.GetComponent<CircleCollider2D>().radius;

    }

    // Update is called once per frame
    void Update()
    {
        //printDirectionVectors();
        checkTouch();
    }

    // Debug function
    private void printDirectionVectors()
    {
        Debug.Log("Movement Direction Vector: " + getMovementDirectionVec().x + getMovementDirectionVec().y);
        Debug.Log("Aiming Direction Vector: " + getAimingDirectionVec().x + getAimingDirectionVec().y);
    }

    private void checkTouch()
    {
        // Check if player has touched the joystick
        foreach (Touch touch in Input.touches)
        {
            fingerID = touch.fingerId;
            if (fingerID >= 0 && fingerID < Input.touchCount && Input.GetTouch(fingerID).phase != TouchPhase.Ended)
            {
                Vector2 f_pos = Input.GetTouch(fingerID).position;
                // Check if player is moving the movement joystick
                if (Input.GetTouch(fingerID).position.x < Screen.width / 2)
                {
                    isIdle[0] = false;
                    if (Vector2.Distance(resetPosition[0], f_pos) <= boundaryRadius)
                    {
                        movementJoy.transform.position = f_pos;
                    }
                    else
                    {
                        Vector2 dirVec = f_pos - resetPosition[0];
                        dirVec.Normalize();
                        movementJoy.transform.position = new Vector2((dirVec.x * (boundaryRadius)) + resetPosition[0].x, (dirVec.y * (boundaryRadius)) + resetPosition[0].y);
                    }
                }

                // Check if the layer is moving the aiming joystick
                if (Input.GetTouch(fingerID).position.x > Screen.width / 2)
                {
                    isIdle[1] = false;
                    if (Vector2.Distance(resetPosition[1], f_pos) <= boundaryRadius)
                    {
                        aimingJoy.transform.position = Input.GetTouch(fingerID).position;
                    }
                    else
                    {
                        Vector2 dirVec = f_pos - resetPosition[1];
                        dirVec.Normalize();
                        aimingJoy.transform.position = new Vector3((dirVec.x * (boundaryRadius)) + resetPosition[1].x, (dirVec.y * (boundaryRadius)) + resetPosition[0].y);
                    }
                }
            }
            else
            {
                Debug.Log("Finger ID: " + fingerID);
                if (fingerID < 2)
                    isIdle[fingerID] = true;
                resetJoyPosition(fingerID);
            }
        }
    }

    private void resetJoyPosition(int a_index)
    {
        if (a_index == 0)
            movementJoy.transform.position = resetPosition[0];
        else if (a_index == 1)
            aimingJoy.transform.position = resetPosition[1];
    }

    private void resetAimingJoy()
    {
        aimingJoy.transform.position = resetPosition[1];
    }
    //##########################################
    // Getters
    //##########################################

    public bool getIdle(int a_index)
    {
        return isIdle[a_index];
    }

    // Get direction vector of the movement stick
    public Vector2 getMovementDirectionVec()
    {
        Vector2 out_vec = new Vector2();
        if (isIdle[0])
        {
            out_vec.x = out_vec.y = 0.0f;
        }
        else
        {
            Vector2 stickPos = new Vector2(movementJoy.transform.position.x, movementJoy.transform.position.y);
            out_vec = stickPos - resetPosition[0];
            out_vec.Normalize();
        }
        return out_vec;
    }

    // Get direction vector of the aiming stick
    public Vector2 getAimingDirectionVec()
    {
        Vector2 out_vec = new Vector2();
        if (isIdle[1])
        {
            out_vec.x = out_vec.y = 0.0f;
        }
        else
        {
            Vector2 stickPos = new Vector2(aimingJoy.transform.position.x, aimingJoy.transform.position.y);
            out_vec = stickPos - resetPosition[1];
            out_vec.Normalize();
        }
        return out_vec;
    }
}
