using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	int movespeedlevel;
	int damagelevel;
	int ammolevel;
	int attackspeedlevel;

	// Use this for initialization
	void Start () {
		movespeedlevel = damagelevel = ammolevel = attackspeedlevel = 0;
	}


	public void AddLevel(string a_toadd)
	{
		if (a_toadd == "movespeed")
			movespeedlevel++;
		else if (a_toadd == "damage")
			damagelevel++;
		else if (a_toadd == "ammo")
			ammolevel++;
		else if (a_toadd == "attackspeed")
			attackspeedlevel++;
	}

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


}
