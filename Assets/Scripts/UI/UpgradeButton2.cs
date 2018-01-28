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
            cost *= 2;

            int teeth = gear2.gearTeeths;
            if (teeth != 17)
            {
                switch (teeth)
                {
                    case 8:
                        playerController.changeGear(2, 11);
                        break;
                    case 11:
                        playerController.changeGear(2, 17);
                        GetComponent<Image>().color = Color.grey;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
