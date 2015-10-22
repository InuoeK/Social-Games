using UnityEngine;
using System.Collections;

public class UIControlInitialization : MonoBehaviour
{

    public GameObject movementBoundary;
    public GameObject aimingBoundary;

    private float[] movementWidthPercentile = new float[2] { 0.2f, 0.8f };
    private float heightPercentile = 0.75f;



    // Use this for initialization
    void Start()
    {

        // Reposition UI elements so they are the same on every device
        movementBoundary.transform.localPosition = new Vector3(Screen.width * movementWidthPercentile[0],
                                                               Screen.height * heightPercentile, 1.0f);
        aimingBoundary.transform.localPosition = new Vector3(Screen.width * movementWidthPercentile[1],
                                                             Screen.height * heightPercentile, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
