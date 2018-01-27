using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlaveGearController : GearController {

    public GameObject masterGear;
    public GameObject beltObject;

    private float offset;
    private float prevAngle;
    private float gearRatio;

    void Start()
    {
        Init();
    }

    public override void changeGear(int newSize)
    {
        base.changeGear(newSize);
        Init();
    }

    public void Init()
    {
        offset = masterGear.transform.rotation.eulerAngles.z;
        prevAngle = transform.rotation.eulerAngles.z;
        gearRatio = (float)masterGear.GetComponent<GearController>().gearTeeths / (float)gearTeeths;
    }

    void LateUpdate()
    {
        float curAngle = transform.rotation.eulerAngles.z;
        float newOffset = ( masterGear.transform.rotation.eulerAngles.z - offset ) * gearRatio;

        /* FIXME .. 
         * 
         mgo: 359.5211 / Offset:358.1335 / NewOffset: 1.387665
         mgo: 0.17362 / Offset:359.5211 / NewOffset: -359.3475
         Tick from gear
         mgo: 0.8000239 / Offset:0.17362 / NewOffset: 0.6264039
         * 
        if (beltObject != null && newOffset != 0.0f)
            Debug.Log("mgo: "+ masterGear.transform.rotation.eulerAngles.z + " / Offset:" + offset + " / NewOffset: "+newOffset);
            */

        offset = masterGear.transform.rotation.eulerAngles.z;

        transform.Rotate(new Vector3(0, 0, -newOffset));
        CheckFullRotation(-newOffset, curAngle);
    }

    void CheckFullRotation(float newOffset, float curAngle)
    {
        // Current object doesn't have reference to belt.. futher checking is useless
        if (beltObject == null)
        {
            return;
        }

        // Determine, if we have rolled one round
        if ((newOffset > 0 && curAngle < prevAngle) || (newOffset < 0 && curAngle > prevAngle))
        {
            beltObject.GetComponent<ConveyorScript>().TickFromGear();
        }

        prevAngle = curAngle;
    }

}
