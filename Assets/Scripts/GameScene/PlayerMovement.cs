using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public int debug;


    public float moveSpeedMult = 10.0f;
    private ControlModule cm;
    public float maxSpeed;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cm = GameObject.Find("GameController").GetComponent<ControlModule>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 joyVec = cm.getMovementDirectionVec();
        if (cm.IsMovementJoyActive() && joyVec != Vector2.zero && rb.velocity.x < maxSpeed){ rb.velocity = joyVec * moveSpeedMult;}
        else { rb.velocity = Vector2.zero; }
    }
}
