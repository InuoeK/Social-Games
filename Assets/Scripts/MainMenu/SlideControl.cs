using UnityEngine;
using System.Collections;

public class SlideControl : MonoBehaviour
{

    private Vector2 touchStartPos;
    private Vector2 defaultSlidePos;

    // Use this for initialization
    void Start()
    {
        touchStartPos = Vector2.zero;
        defaultSlidePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!CheckTouchingSlide())
        {
            transform.position = Vector2.Lerp(transform.position, defaultSlidePos, Time.deltaTime * 8.0f);
            touchStartPos = Vector2.zero;
        }
    }

    public bool CheckSlideLimit()
    {
        if (transform.position.x > 6) { return true; }
        else { return false; }
    }

    // Check if the player is touching the slide
    public bool CheckTouchingSlide()
    {
        foreach (Touch t in Input.touches)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(t.position);
            Vector2 tPos = new Vector2(wp.x, wp.y);
            Collider2D hit = Physics2D.OverlapPoint(tPos);
            if (hit && hit.gameObject.name == "Slide")
            {
                if (t.phase == TouchPhase.Began)
                {
                    touchStartPos = tPos;
                    Debug.Log("Touch Detected");
                }
                SlideFollowTouch(tPos);
                return true;
            }
        }
        return false;
    }

    private void SlideFollowTouch(Vector2 a_tPos)
    { transform.position = Vector2.Lerp(transform.position, new Vector2((a_tPos - touchStartPos).x, transform.position.y), Time.deltaTime * 8.0f); }
}
