using UnityEngine;
using System.Collections;

public class PublicTouchFunctions : MonoBehaviour {

    public bool CheckTouchObject(string a_objName)
    {
        foreach (Touch t in Input.touches)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(t.position);
            Vector2 tPos = new Vector2(wp.x, wp.y);
            Collider2D hit = Physics2D.OverlapPoint(tPos);
            if (hit && hit.gameObject.name == a_objName
                && t.phase == TouchPhase.Began)
                return true;
        }
        return false;
    }
}
