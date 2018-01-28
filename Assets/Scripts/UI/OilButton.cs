using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilButton : UIButton
{
    public Rigidbody gearRB;

    float targetValue;
    bool updating;

    public override void action()
    {
        if(playerController.money >= cost)
        {
            playerController.addMoney(-cost);
            if(gearRB.angularDrag > 1.5f)
            {
                targetValue = gearRB.angularDrag - 0.5f;
            }
            else
            {
                targetValue = 1.0f;
            }
            updating = true;
        }
    }

    private void Update()
    {
        if(gearRB.angularDrag > targetValue && updating)
        {
            gearRB.angularDrag -= Time.deltaTime * 2.0f;
            if(gearRB.angularDrag < targetValue)
            {
                updating = false;
                gearRB.angularDrag = targetValue;
            }
        }
    }
}
