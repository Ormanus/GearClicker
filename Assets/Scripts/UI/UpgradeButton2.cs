using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton2 : UIButton
{
    public GearController gear2;

    public override void action()
    {
        if (playerController.money >= cost)
        {
            playerController.addMoney(-cost);

            int teeth = gear2.gearTeeths;
            if (teeth != 17)
            {
                switch (teeth)
                {
                    case 8:
                        playerController.changeGear(2, 11);
                        cost = 15;
                        break;
                    case 11:
                        playerController.changeGear(2, 17);
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
