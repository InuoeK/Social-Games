using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    // Pointers to the text elements that will show the player how much money they have
    public Text shopSquareBucks;
    public Text battleSquareBucks;

	int movespeedlevel;
	int damagelevel;
	int ammolevel;
	int attackspeedlevel;

    float squareBucks;
    float curSquareBucksValue;
    float updateValue;


	int maxAmmo;
	int currentAmmo;
	// Use this for initialization
	void Start() {
        movespeedlevel = damagelevel = ammolevel = attackspeedlevel = 1;
		currentAmmo = maxAmmo = 10;
        squareBucks = 10000;
        curSquareBucksValue = 0.0f;
        updateValue = 0.0f;
	}

    void Update()
    {
        UpdateSquareBucksUI();
        UpdateAmmoText();
    }


    /// <summary>
    /// Add a_levelstoadd levels to player attribute a_toadd
    /// </summary>
    /// <param name="a_toadd"></param>
    /// <param name="a_levelstoadd"></param>
	public void AddLevel(string a_toadd, int a_levelstoadd)
	{
		if (a_toadd == "movespeed")
			movespeedlevel += a_levelstoadd;
		else if (a_toadd == "damage")
			damagelevel += a_levelstoadd;
		else if (a_toadd == "ammo") {
			ammolevel += a_levelstoadd;
			UpdateMaxAmmo();
		}
		else if (a_toadd == "attackspeed")
			attackspeedlevel+=a_levelstoadd;
	}

	void UpdateMaxAmmo()
	{
		maxAmmo = 10 + ammolevel * 2;
	}

    void UpdateAmmoText()
    {
        GameObject.Find("ammotext").GetComponent<Text>().text = "Ammo: " + currentAmmo + " / " + maxAmmo;
    }
	public void ReloadAmmo()
	{
		currentAmmo = maxAmmo;
		GameObject.Find ("ammotext").GetComponent<Text> ().text = currentAmmo.ToString ();
	}

	public void ChangeCurrentAmmo(int a_int)
	{
		currentAmmo += a_int;
		GameObject.Find ("ammotext").GetComponent<Text> ().text = currentAmmo.ToString ();
	}

	public int GetCurrentAmmo()
	{
		return currentAmmo;
	}

    public bool NeedToReload()
    {
        if (currentAmmo != maxAmmo)
            return true;
        else
            return false;
    }

    /// <summary>
    /// Get the level of the player's stat 
    /// Valid arguments:
    /// movespeed
    /// damage
    /// ammo
    /// attackspeed
    /// </summary>
    /// <param name="a_toget"></param>
    /// <returns></returns>
	public int GetLevel(string a_toget)
	{
 
		if (a_toget == "movespeed")
			return movespeedlevel;
		else if (a_toget == "damage")
			return damagelevel;
		else if (a_toget == "ammo")
			return ammolevel;
		else if (a_toget == "attackspeed")
			return attackspeedlevel;
     

		return -1;
	}

    /// <summary>
    /// Change the amount of money the player has. Negative values subtract.
    /// </summary>
    /// <param name="a_int"></param>
    public void AdjustSquareBucks(int a_int)
    {
        squareBucks += a_int;
    }

    public void UpdateSquareBucksUI()
    {
        if ((int)curSquareBucksValue != (int)squareBucks)
        {
            float tempValue;
            tempValue = Mathf.Lerp(curSquareBucksValue, squareBucks, updateValue);
            updateValue += Time.deltaTime*0.75f;
            shopSquareBucks.text = ((int)tempValue).ToString();
            battleSquareBucks.text = ((int)tempValue).ToString();
   
        }
        if (updateValue >= 1.0f)
        {
            curSquareBucksValue = squareBucks;
            updateValue = 0.0f;
            shopSquareBucks.text = ((int)squareBucks).ToString();
            battleSquareBucks.text = ((int)squareBucks).ToString();
        }

    }

    public float GetSquareBucks()
    {
        return squareBucks;
    }

}
