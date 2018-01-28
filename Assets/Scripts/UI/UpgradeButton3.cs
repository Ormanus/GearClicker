using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton3 : UIButton
{
    public GearController gear3;

    public override void action()
    {
        if (playerController.money >= cost)
        {
            playerController.addMoney(-cost);

            int teeth = gear3.gearTeeths;
            if (teeth != 7)
            {
                switch (teeth)
                {
                    case 17:
                        playerController.changeGear(3, 11);
                        cost = 15;
                        break;
                    case 11:
                        playerController.changeGear(3, 7);
                        cost = 25;
                        ResetTarget();
                        gameObject.SetActive(false);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
