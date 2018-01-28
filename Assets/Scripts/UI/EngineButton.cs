using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineButton : UIButton
{
    public GameObject engineObject;
    public Text text;

    public override void action()
    {
        if (playerController.money >= cost)
        {
            playerController.addMoney(-cost);
            cost += 200;

            if (engineObject.activeInHierarchy)
            {
                playerController.enginePower *= 1.5f;
            }
            else
            {
                engineObject.SetActive(true);
                playerController.engine = true;
                text.text = "Upgrade Engine";
            }
        }
    }
}
