using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RewardGenerator : MonoBehaviour
{

    public GameObject Player;

    private BaseAttributesAndCommands bac;

    // Use this for initialization
    void Start()
    {
        bac = Player.GetComponent<BaseAttributesAndCommands>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateReward(float a_reward, string a_rewardType)
    {
        if (a_rewardType == "Food")
            GivePlayerFood(a_reward);
        if (a_rewardType == "Resources")
            GivePlayerResources(a_reward);
    }

    public void GivePlayerResources(float a_resourceToGive)
    {
        Debug.Log("Reward given");
        bac.Chg_CurResources(a_resourceToGive);
    }

    public void GivePlayerFood(float a_foodToGive)
    {
        bac.Chg_CurFood(a_foodToGive);
    }

    void CreateUpdateMessage(Task a_task, float a_reward, string a_rewardType)
    {
        GameObject newRewardMessage = Instantiate(Resources.Load("RewardMessage")) as GameObject;
        newRewardMessage.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 1.0f);
        newRewardMessage.transform.parent = GameObject.Find("UICanvas").transform;

        newRewardMessage.GetComponentInChildren<Text>().text =
            a_task.type + " " + a_task.location + " completed!" + "\n" +
            a_reward + " " + a_rewardType + " received!";

        newRewardMessage.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
}
