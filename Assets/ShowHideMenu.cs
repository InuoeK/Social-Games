using UnityEngine;
using System.Collections;

public class ShowHideMenu : MonoBehaviour {

	public GameObject prepMenu;
	public GameObject shopMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Valid arguments:
    /// prep
    /// shop
    /// </summary>
    /// <param name="a_menu"></param>
	public void ShowMenu(string a_menu)
	{
		if (a_menu == "prep")
			prepMenu.SetActive (true);
		else if (a_menu == "shop")
			shopMenu.SetActive (true);
	}

	public void HideMenu(string a_menu)
	{
		if (a_menu == "prep") {
			prepMenu.SetActive (false);
			this.gameObject.GetComponent<GameState>().SetInBattle(true);
		}
		else if (a_menu == "shop")
			shopMenu.SetActive (false);
	}
}
