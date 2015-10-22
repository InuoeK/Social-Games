using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{

    public int movementSpeed;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-movementSpeed, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
