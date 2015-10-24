using UnityEngine;
using System.Collections;
using System;   

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
            float damage = 3.0f;
            damage += GameObject.Find("Player").GetComponent<PlayerStats>().GetLevel("damage") * 0.25f;

            //Add some random factor to the damage
            float divisor = UnityEngine.Random.Range(60, 100);

            // do between 70-100% of calculated damage
            damage /= (divisor / 100.0f);
            damage = (float)Math.Round(damage, 2);
            GameObject.Find("GameController").GetComponent<CombatModule>().DealDamage(damage, _other.gameObject);
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D _other)
    {
        GameObject.Find("GameController").GetComponent<CombatModule>().DealDamage(5, _other.gameObject);
        Destroy(this.gameObject);
    }
}
