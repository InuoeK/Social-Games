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

    void MovePlayer()
    {
    	if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
			CheckMobileControls ();

		if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
			CheckComputerControls();
    }

	void CheckComputerControls()
	{
		Vector2 moveVec = new Vector2 (0, 0);
		if (Input.GetKey ("w"))
			moveVec.y += moveSpeedMult;

		if (Input.GetKey ("a"))
			moveVec.x -= moveSpeedMult;

		if (Input.GetKey ("d"))
			moveVec.x += moveSpeedMult;
	
		if (Input.GetKey ("s"))
			moveVec.y -= moveSpeedMult;

		 if (rb.velocity.magnitude < maxSpeed)
			rb.velocity = moveVec;
	
	}

	void CheckMobileControls()
	{
		Vector2 joyVec = cm.getMovementDirectionVec();
		if (cm.IsMovementJoyActive() && joyVec != Vector2.zero && rb.velocity.x < maxSpeed){ rb.velocity = joyVec * moveSpeedMult;}
		else { rb.velocity = Vector2.zero; }
	}
}
