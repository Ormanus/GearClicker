using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGearController : GearController
{
    public void ApplyImpulse(float force)
    {
        GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, -force), ForceMode.Impulse);
    }
}