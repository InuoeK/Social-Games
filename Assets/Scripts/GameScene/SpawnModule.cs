using UnityEngine;
using System.Collections;

public class SpawnModule : MonoBehaviour {
    public float spawnChance;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        SimpleSpawning();
	
	}

    private void SimpleSpawning()
    {
        if(Random.Range(0, 100) < spawnChance)
            Instantiate(Resources.Load("Enemy"),new Vector3(10, Random.Range(-4,4)), Quaternion.identity);
    }
}
