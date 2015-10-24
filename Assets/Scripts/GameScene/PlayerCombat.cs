using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


public class PlayerCombat : MonoBehaviour
{

    float baseFireCooldown;
    float reloadTime;
    float reloadTimer;
    float elapsedTime;
    bool isReloading;
    public float bulletSpeed;
    private ControlModule cm;

    public GameObject reloadMessage;
    public GameObject reloadNotification;

    // Use this for initialization
    void Start()
    {
        reloadTime = 1.5f;
        isReloading = false;
        baseFireCooldown = 1.0f;
        cm = GameObject.Find("GameController").GetComponent<ControlModule>();
    }

    // Update is called once per frame
    void Update()
    {
		elapsedTime += Time.deltaTime;
        if (OkayToShoot() && !isReloading && this.gameObject.GetComponent<PlayerStats>().GetCurrentAmmo() > 0)
        {
            if (GameObject.Find("GameController").GetComponent<GameState>().GetInBattle())
            {
                if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
                    CheckMobileControls();

                if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                    CheckComputerControls();
            }
        }

        if (this.gameObject.GetComponent<PlayerStats>().GetCurrentAmmo() == 0)
        {
            reloadNotification.SetActive(true);
        }
        else
            reloadNotification.SetActive(false);

        if (Input.GetKey("r") && GameObject.Find("Player").GetComponent<PlayerStats>().NeedToReload())
        {
            SetIsReloadingTrue();
        }

        if (isReloading) 
            CheckReload();
    }


    void SetIsReloadingTrue()
    {
        isReloading = true;
        reloadMessage.SetActive(true);
    }

    void CheckReload()
    {
        reloadTimer += Time.deltaTime;
        reloadMessage.GetComponentInChildren<Text>().text =
            "Reloading\n" + Math.Round((reloadTimer / reloadTime * 100.0f), 2) + "%";
        if (reloadTimer >= reloadTime)
        {
            Reload();
            reloadTimer = 0.0f;
            isReloading = false;
            reloadMessage.SetActive(false);
        }
    }



	void Reload()
	{
		GameObject.Find ("Player").GetComponent<PlayerStats> ().ReloadAmmo ();
	}

    // Checks cool down for shooting
    bool OkayToShoot()
    {
        if (elapsedTime >= baseFireCooldown - (0.02 * this.gameObject.GetComponent<PlayerStats>().GetLevel("attackspeed")))
        {

            return true;
        }

        return false;
    }

    private void CheckMobileControls()
    {
        Vector2 aimJoy = cm.getAimingDirectionVec();
        if (cm.IsAimingJoyActive())
        {
			elapsedTime = 0.0f;
            GameObject t = Instantiate(Resources.Load("proj"), GameObject.Find("Player").transform.position, Quaternion.identity) as GameObject;

            t.GetComponent<Rigidbody2D>().velocity = new Vector2(aimJoy.x * bulletSpeed, aimJoy.y * bulletSpeed);
			Quaternion q = Quaternion.AngleAxis(Mathf.Atan2(aimJoy.x, aimJoy.y) * -180 / Mathf.PI, new Vector3(0, 0, 1));
            t.transform.rotation = q;
        }
    }

	void CheckComputerControls()
	{
		if(GameObject.Find ("Player").GetComponent<PlayerStats>().GetCurrentAmmo()>0)
		if(Input.GetMouseButton(0))
		{	
			elapsedTime = 0.0f;
			Vector2 normalizedVec = Camera.main.ScreenToWorldPoint(Input.mousePosition) - GameObject.Find ("Player").transform.position;
			normalizedVec.Normalize();
			GameObject t = Instantiate (Resources.Load ("proj"), GameObject.Find ("Player").transform.position, Quaternion.identity) as GameObject;
				
			t.GetComponent<Rigidbody2D>().velocity = new Vector2 (normalizedVec.x * bulletSpeed, normalizedVec.y * bulletSpeed);
			Quaternion q = Quaternion.AngleAxis (Mathf.Atan2 (normalizedVec.x, normalizedVec.y) * -180 / Mathf.PI, new Vector3(0,0, 1));
			t.transform.rotation = q;	
			GameObject.Find ("Player").GetComponent<PlayerStats>().ChangeCurrentAmmo(-1);
		}
	}
}
