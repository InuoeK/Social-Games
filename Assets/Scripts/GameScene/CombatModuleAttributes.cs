using UnityEngine;
using System.Collections;

public class CombatModuleAttributes : MonoBehaviour {

    public int health;

    public int damage;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ModifyHealth(int a_modint)
    {
        health += a_modint;

        if (health <= 0)
            Destroy(this.gameObject);
    }

    
}
