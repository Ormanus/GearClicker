using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGearController : GearController
{
    Rigidbody rb;

    float prevAngle = 0.0f;

    public void ApplyImpulse(float force)
    {
        rb.AddTorque(new Vector3(0, 0, -force), ForceMode.Impulse);

        if(rb.angularDrag < 2.0f)
        {
            rb.angularDrag += force * 0.02f;
        }
    }

    public void Start()
    {
        prevAngle = transform.rotation.eulerAngles.z;
        rb = GetComponent<Rigidbody>();
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