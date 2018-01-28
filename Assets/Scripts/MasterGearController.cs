using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGearController : GearController
{
    float prevAngle = 0.0f;

    public void ApplyImpulse(float force)
    {
        GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, -force), ForceMode.Impulse);
    }

    public void Start()
    {
        prevAngle = transform.rotation.eulerAngles.z;
    }

    public void Update()
    {
        float offset = transform.rotation.eulerAngles.z - prevAngle;
        if (offset == 0.0f)
            return;

        // Did Internal counter reset?
        if (offset < 0.0f)
        {
            offset += 360.0f;
        }

        //
        changeCounter(offset);

        //
        prevAngle = transform.rotation.eulerAngles.z;
    }
}