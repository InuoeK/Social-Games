using UnityEngine;
using System.Collections;


public class MenuStateModule : MonoBehaviour
{

    GameObject gunObject;
    GameObject mainCam;

    MainMenuState menuState;

    public float transitionSpeedMult;

    // Use this for initialization
    void Start()
    {
        menuState = MainMenuState.Intro;
        gunObject = GameObject.Find("GunObject");
        mainCam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        StateSpecificActions();
        TransitionCamera();
    }

    private void StateSpecificActions()
    {
        switch (menuState)
        {
            case (MainMenuState.Intro):
                CheckSlideDrag();
                break;
            case (MainMenuState.Root):
                CheckTouchMagazine();
                CheckTouchSlide();
                CheckTouchTrigger();
                break;
            case (MainMenuState.Options):
                CheckTouchMagazineBottom();
                break;
        };
    }


    private void CheckTouchTrigger()
    {
        if (gunObject.GetComponentInChildren<PistolTriggerScript>().CheckTouchTrigger())
            Application.LoadLevel("GameScene");
    }

    private void CheckTouchSlide()
    {
        if (gunObject.GetComponentInChildren<SlideControl>().CheckTouchingSlide())
            SwitchState(MainMenuState.Intro);
    }

    private void CheckTouchMagazineBottom()
    {
        if (gunObject.GetComponentInChildren<MagazineCheckTouch>().CheckTouchMagazineBottom())
            SwitchState(MainMenuState.Root);
    }

    // Check if the player has touched the magazine while in root mode so the game
    // will transition to the options menu
    private void CheckTouchMagazine()
    {
        if (gunObject.GetComponentInChildren<MagazineCheckTouch>().CheckTouchMagazine())
            SwitchState(MainMenuState.Options);
    }

    // Check if the player has dragged the pistol's slide to determine whether to
    // transition to the main menu
    private void CheckSlideDrag()
    {
        if (gunObject.GetComponentInChildren<SlideControl>().CheckSlideLimit())
            SwitchState(MainMenuState.Root);
    }

    private void TransitionCamera()
    {
        if (menuState == MainMenuState.Intro)
        {
            mainCam.transform.position = Vector3.Slerp(mainCam.transform.position, GameObject.Find("CameraDefaultPosition").transform.position, Time.deltaTime * transitionSpeedMult);
            mainCam.transform.rotation = Quaternion.Slerp(mainCam.transform.rotation, GameObject.Find("CameraDefaultPosition").transform.rotation, Time.deltaTime * transitionSpeedMult);
            mainCam.GetComponent<Camera>().orthographicSize = Mathf.Lerp(mainCam.GetComponent<Camera>().orthographicSize, 5, Time.deltaTime * transitionSpeedMult);
        }

        if (menuState == MainMenuState.Root)
        {
            mainCam.transform.position = Vector3.Slerp(mainCam.transform.position, GameObject.Find("CameraRootPosition").transform.position, Time.deltaTime * transitionSpeedMult);
            mainCam.transform.rotation = Quaternion.Slerp(mainCam.transform.rotation, GameObject.Find("CameraRootPosition").transform.rotation, Time.deltaTime * transitionSpeedMult);
            GameObject.Find("MagazineBottom").transform.position = Vector3.Lerp(GameObject.Find("MagazineBottom").transform.position, GameObject.Find("MagazineDefaultState").transform.position, Time.deltaTime * transitionSpeedMult);
            mainCam.GetComponent<Camera>().orthographicSize = Mathf.Lerp(mainCam.GetComponent<Camera>().orthographicSize, 3, Time.deltaTime * transitionSpeedMult);
        }

        if (menuState == MainMenuState.Options)
        {
            mainCam.transform.position = Vector3.Slerp(mainCam.transform.position, GameObject.Find("CameraOptionsPosition").transform.position, Time.deltaTime * transitionSpeedMult);
            mainCam.transform.rotation = Quaternion.Slerp(mainCam.transform.rotation, GameObject.Find("CameraOptionsPosition").transform.rotation, Time.deltaTime * transitionSpeedMult);
            GameObject.Find("MagazineBottom").transform.position = Vector3.Lerp(GameObject.Find("MagazineBottom").transform.position, GameObject.Find("MagazineOptionsState").transform.position, Time.deltaTime * transitionSpeedMult);
            mainCam.GetComponent<Camera>().orthographicSize = Mathf.Lerp(mainCam.GetComponent<Camera>().orthographicSize, 9, Time.deltaTime * transitionSpeedMult);
        }
    }

    public void SwitchState(MainMenuState a_state)
    {
        menuState = a_state;
    }

    public MainMenuState GetMenuState()
    {
        return menuState;
    }
}
