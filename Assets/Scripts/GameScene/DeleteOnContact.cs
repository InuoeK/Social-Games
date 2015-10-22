using UnityEngine;
using System.Collections;

public class DeleteOnContact : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.CompareTag("Enemy"))
        {
            GameObject.Find("GameController").GetComponent<CombatModule>().DealDamage(Random.Range(1,10), _other.gameObject);
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D _other)
    {
        GameObject.Find("GameController").GetComponent<CombatModule>().DealDamage(5, _other.gameObject);
        Destroy(this.gameObject);
    }
}
