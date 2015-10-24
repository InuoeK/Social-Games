using UnityEngine;
using System.Collections;



public class PlayerCombat : MonoBehaviour
{

    float baseFireCooldown;
    float elapsedTime;
    public float bulletSpeed;
    private ControlModule cm;


    // Use this for initialization
    void Start()
    {
        baseFireCooldown = 1.0f;
        cm = GameObject.Find("GameController").GetComponent<ControlModule>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OkayToShoot())
        {
            if (GameObject.Find("GameController").GetComponent<GameState>().GetInBattle())
            {
                if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
                    CheckMobileControls();

                if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                    CheckComputerControls();
            }
        }
    }

    // Checks cool down for shooting
    bool OkayToShoot()
    {
        if (elapsedTime >= baseFireCooldown - (0.02 * this.gameObject.GetComponent<PlayerStats>().GetLevel("attackspeed")))
        {
            elapsedTime = 0.0f;
            return true;
        }
        elapsedTime += Time.deltaTime;
        return false;
    }

    private void CheckMobileControls()
    {
        Vector2 aimJoy = cm.getAimingDirectionVec();
        if (cm.IsAimingJoyActive())
        {
            GameObject t = Instantiate(Resources.Load("proj"), GameObject.Find("Player").transform.position, Quaternion.identity) as GameObject;

            t.GetComponent<Rigidbody2D>().velocity = new Vector2(aimJoy.x * bulletSpeed, aimJoy.y * bulletSpeed);
			Quaternion q = Quaternion.AngleAxis(Mathf.Atan2(aimJoy.x, aimJoy.y) * -180 / Mathf.PI, new Vector3(0, 0, 1));
            t.transform.rotation = q;
        }
    }

	void CheckComputerControls()
	{
		if(Input.GetMouseButton(0))
		{	
			Vector2 normalizedVec = Camera.main.ScreenToWorldPoint(Input.mousePosition) - GameObject.Find ("Player").transform.position;
			normalizedVec.Normalize();
			GameObject t = Instantiate (Resources.Load ("proj"), GameObject.Find ("Player").transform.position, Quaternion.identity) as GameObject;
				
			t.GetComponent<Rigidbody2D>().velocity = new Vector2 (normalizedVec.x * bulletSpeed, normalizedVec.y * bulletSpeed);
			Quaternion q = Quaternion.AngleAxis (Mathf.Atan2 (normalizedVec.x, normalizedVec.y) * -180 / Mathf.PI, new Vector3(0,0, 1));
			t.transform.rotation = q;				
		}
	}
}
