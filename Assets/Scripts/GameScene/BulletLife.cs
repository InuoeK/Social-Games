using UnityEngine;
using System.Collections;

public class BulletLife : MonoBehaviour {
    public float lifeInSeconds;

	// Use this for initialization
	void Start () {  
	}
	
	// Update is called once per frame
	void Update () {
        DestroyOrDecreaseLife();
	}

    private void DestroyOrDecreaseLife()
    {
        if (lifeInSeconds < 0.0f)
            Destroy(this.gameObject);
        lifeInSeconds -= Time.deltaTime;
    }
}
