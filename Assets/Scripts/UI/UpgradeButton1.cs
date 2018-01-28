using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton1 : UIButton
{
    public GearController gear1;

    public override void action()
    {
        if(playerController.money >= cost)
        {
            playerController.addMoney(-cost);
            cost *= 2;

            int teeth = gear1.gearTeeths;

            if (teeth != 17)
            {
                switch (teeth)
                {
                    case 8:
                        gear1.changeGear(11);
                        break;
                    case 11:
                        gear1.changeGear(17);
                        GetComponent<Image>().color = Color.grey;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
