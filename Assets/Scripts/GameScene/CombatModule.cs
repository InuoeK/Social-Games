using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CombatModule : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DealDamage(int a_damage, GameObject a_target)
    {
        if (a_target.GetComponent<CombatModuleAttributes>())
        {
            a_target.GetComponent<CombatModuleAttributes>().ModifyHealth(-a_damage);
            Vector2 ss = Camera.main.WorldToScreenPoint(a_target.transform.position);

            GameObject a = Instantiate(Resources.Load("DamageText"), ss, Quaternion.identity) as GameObject;
            a.GetComponent<DamageText>().SetText("" + a_damage);
        }
    }


}
