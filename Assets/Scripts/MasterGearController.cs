using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGearController : GearController
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ApplyImpulse(float force)
    {
        rb.AddTorque(new Vector3(0, 0, -force), ForceMode.Impulse);

        if(rb.angularDrag < 2.0f)
        {
            rb.angularDrag += force * 0.02f;
        }
    }
}