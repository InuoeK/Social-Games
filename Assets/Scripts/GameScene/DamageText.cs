using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.parent = GameObject.Find("UI_Controls").transform;
        GetComponent<Text>().fontSize = 80;
        GetComponent<Rigidbody2D>().velocity = new Vector2(30, 50); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetText(string a_text)
    {
        GetComponent<Text>().text = a_text;
    }
}
