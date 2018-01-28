using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineButton : UIButton
{
    public override void action()
    {
        if (playerController.money >= cost)
        {
            playerController.addMoney(-cost);
        }
    }

}
