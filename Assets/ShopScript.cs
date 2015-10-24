using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Controls everything that goes on during the shop ui state
// IE: Buying equipment and upgrading player stats

public class ShopScript : MonoBehaviour {

    public PlayerStats playerStats;


    float moneyToBeSpent;


    string baseText = "Lv. ";
    // Correspond according to the upgrade list (from top to bottom)
    // 1) Movement speed
    // 2) Damage
    // 3) Ammo
    // 4) Attack speed

    int[] upgrade = new int[4];

    void Start()
    {
        moneyToBeSpent = 0.0f;
    }

    void Update()
    {
        UpdateCostToUpgradeText();
    }

    void UpdateCostToUpgradeText()
    {
        GameObject.Find("amountToSpend").GetComponentInChildren<Text>().text = ((int)moneyToBeSpent).ToString();
        if (moneyToBeSpent == 0.0f)
            GameObject.Find("amountToSpend").GetComponentInChildren<Text>().text = "";
    }


    public void ResetUpgradeValues()
    {
        for (int i = 0; i < upgrade.Length; i++)
        {
            upgrade[i] = 0;
        }
    }

    public void ResetUpgradeText()
    {
        GameObject.Find("movespeedlevel").GetComponentInChildren<Text>().text = baseText + (playerStats.GetLevel("movespeed"));
        GameObject.Find("damagelevel").GetComponentInChildren<Text>().text = baseText + (playerStats.GetLevel("damage"));
        GameObject.Find("ammolevel").GetComponentInChildren<Text>().text = baseText + (playerStats.GetLevel("ammo"));
        GameObject.Find("attackspeedlevel").GetComponentInChildren<Text>().text = baseText + (playerStats.GetLevel("attackspeed"));
    }

    public void RefundPlayer()
    {
        playerStats.AdjustSquareBucks((int)moneyToBeSpent);
        moneyToBeSpent = 0.0f;
      
    }

    void UpdateUpgradeLevels(string a_attributetoupdate)
    {
        if (a_attributetoupdate == "movespeed")
            GameObject.Find("movespeedlevel").GetComponentInChildren<Text>().text = baseText + (playerStats.GetLevel(a_attributetoupdate) + " + " + upgrade[0]);
        else if (a_attributetoupdate == "damage")
            GameObject.Find("damagelevel").GetComponentInChildren<Text>().text = baseText + (playerStats.GetLevel(a_attributetoupdate) + " + " + upgrade[1]);
        else if (a_attributetoupdate == "ammo")
            GameObject.Find("ammolevel").GetComponentInChildren<Text>().text = baseText + (playerStats.GetLevel(a_attributetoupdate) + " + " + upgrade[2]);
        else if (a_attributetoupdate == "attackspeed")
            GameObject.Find("attackspeedlevel").GetComponentInChildren<Text>().text = baseText + (playerStats.GetLevel(a_attributetoupdate) + " + " + upgrade[3]);
    }

    public void IncreaseUpgradeLevel(string a_attributeToIncrease)
    {
        int costCheckIndex=-1;
        switch (a_attributeToIncrease)
        {
            case "movespeed":
                costCheckIndex = 0;
                break;
            case "damage":
                costCheckIndex = 1;
                break;
            case "ammo":
                costCheckIndex = 2;
                break;
            case "attackspeed":
                costCheckIndex = 3;
                break;
        }
        if (playerStats.GetSquareBucks() >= ((playerStats.GetLevel(a_attributeToIncrease) + upgrade[costCheckIndex]) * 150) + moneyToBeSpent)
        {
            if (a_attributeToIncrease == "movespeed")
                upgrade[0]++;
            else if (a_attributeToIncrease == "damage")
                upgrade[1]++;
            else if (a_attributeToIncrease == "ammo")
                upgrade[2]++;
            else if (a_attributeToIncrease == "attackspeed")
                upgrade[3]++;
            moneyToBeSpent += (playerStats.GetLevel(a_attributeToIncrease) + upgrade[costCheckIndex]) * 150;
            UpdateUpgradeLevels(a_attributeToIncrease);
        }
    }

    public void AddUpgradeLevels()
    {
        playerStats.AddLevel("movespeed", upgrade[0]);
        playerStats.AddLevel("damage", upgrade[1]);
        playerStats.AddLevel("ammo", upgrade[2]);
        playerStats.AddLevel("attackspeed", upgrade[3]);

        GameObject.Find("movespeedlevel").GetComponentInChildren<Text>().text = baseText + playerStats.GetLevel("movespeed").ToString();
        GameObject.Find("damagelevel").GetComponentInChildren<Text>().text = baseText + playerStats.GetLevel("damage").ToString();
        GameObject.Find("ammolevel").GetComponentInChildren<Text>().text = baseText + playerStats.GetLevel("ammo").ToString();
        GameObject.Find("attackspeedlevel").GetComponentInChildren<Text>().text = baseText + playerStats.GetLevel("attackspeed").ToString();


    
        playerStats.AdjustSquareBucks((int)-moneyToBeSpent);

        moneyToBeSpent = 0;

        Debug.Log("Upgrade levels added");

        ResetUpgradeValues();
    }

    public int GetPendingUpgradeLevel(string a_leveltoget)
    {
        if (a_leveltoget == "movespeed")
            return upgrade[0];
        else if (a_leveltoget == "damage")
            return upgrade[1];
        else if (a_leveltoget == "ammo")
            return upgrade[2];
        else if (a_leveltoget == "movespeed")
            return upgrade[3];

        return -1;
    }
}
