using UnityEngine;
using System.Collections;

public class BaseAttributesAndCommands : MonoBehaviour
{
    private int maxFood;
    private int maxResources;
    private int curFood;
    private int curResources;

    // Use this for initialization
    void Start()
    {
        tempInitValues();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void tempInitValues()
    {
        curFood = maxFood = 10;
        curResources = maxResources = 100;
    }

    public int getCurFood()
    {
        return curFood;
    }

    public int getMaxFood()
    {
        return maxFood;
    }

    public int getCurResources()
    {
        return curResources;
    }

    public int getMaxResources()
    {
        return maxResources;
    }

    public void chg_MaxFood(int i)
    {
        maxFood += i;
    }

    public void chg_MaxResouces(int i)
    {
        maxResources += i;
    }

    public void chg_CurFood(int i)
    {
        curFood += i;
    }

    public void chg_CurResources(int i)
    {
        curResources += i;
    }
}
