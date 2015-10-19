using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateTimeLeft : MonoBehaviour
{

    void UpdateText()
    {
        if (this.transform.parent.GetComponent<Timer>().GetCountdownTime() < 0.0f)
            this.GetComponent<Text>().text = "";
        else
            this.GetComponent<Text>().text = this.transform.parent.GetComponent<Timer>().GetCountdownTime().ToString();
    }
    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }
}
