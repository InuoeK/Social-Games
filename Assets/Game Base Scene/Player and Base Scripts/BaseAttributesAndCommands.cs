using UnityEngine;
using System.Collections;

public class BaseAttributesAndCommands : MonoBehaviour
{

    // Max values define the maximum amount of material the player has
    // cur values are the number representation of how many materials the player has
    // actual values are the visual representation of how many materials the player has

    private float maxFood;
    private float maxResources;
    private float curFood;
    private float curResources;
    private float actualFood;
    private float actualResources;

    // Use this for initialization
    void Start()
    {
        tempInitValues();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateActualValues();
    }


    void UpdateActualValues()
    {
        if (actualFood != curFood)
        {
            actualFood = AdjustValue(actualFood, curFood);
        }
        if (actualResources != curResources)
        {
            actualResources = AdjustValue(actualResources, curResources);
        }
    }

    float AdjustValue(float a_base, float a_target)
    {
        if (a_base < a_target)
        {
            a_base++;
        }
        else if (a_base > a_target)
        {
            a_base--;
        }
        return a_base;
    }

    void tempInitValues()
    {
        curFood = curResources = 0;
        maxFood = 10;
        maxResources = 100;
    }

    public bool CheckIfMaxFood()
    {
        if (curFood == maxFood)
            return true;
        else
            return false;
    }

    public bool CheckIfMaxResources()
    {
        if (curResources == maxResources)
            return true;
        else
            return false;
    }

    public float GetActualFood()
    {
        return actualFood;
    }

    public float GetMaxFood()
    {
        return maxFood;
    }

    public float GetActualResources()
    {
        return actualResources;
    }

    public float GetMaxResources()
    {
        return maxResources;
    }

    public void Chg_MaxFood(float i)
    {
        maxFood += i;
    }

    public void Chg_MaxResouces(float i)
    {
        maxResources += i;
    }

    public void Chg_CurFood(float i)
    {
        curFood += i;
    }

    public void Chg_CurResources(float i)
    {
        curResources += i;
    }
}
