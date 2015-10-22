using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour
{
    public float bulletSpeed;
    private ControlModule cm;

    // Use this for initialization
    void Start()
    {
        cm = GameObject.Find("GameController").GetComponent<ControlModule>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckJoyShootProjectiles();
    }

    private void CheckJoyShootProjectiles()
    {
        Vector2 aimJoy = cm.getAimingDirectionVec();
        if (cm.IsAimingJoyActive())
        {
            GameObject t =
            Instantiate(Resources.Load("proj"), GameObject.Find("Player").transform.position, Quaternion.identity) as GameObject;

            float atan = Mathf.Atan2(aimJoy.x, aimJoy.y);
            t.GetComponent<Rigidbody2D>().velocity = new Vector2(aimJoy.x * bulletSpeed, aimJoy.y * bulletSpeed);
            Quaternion q = Quaternion.AngleAxis(atan * -180 / Mathf.PI, new Vector3(0, 0, 1));
            t.transform.rotation = q;
        }
    }
}
