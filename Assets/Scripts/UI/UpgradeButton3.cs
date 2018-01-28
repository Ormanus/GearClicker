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
            cost *= 2;

            int teeth = gear3.gearTeeths;
            if (teeth != 8)
            {
                switch (teeth)
                {
                    case 8:
                        gear3.changeGear(11);
                        break;
                    case 11:
                        gear3.changeGear(8);
                        GetComponent<Image>().color = Color.grey;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
