using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGearController : GearController
{
    public void ApplyClickToGear()
    {
        GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, -2), ForceMode.Impulse);
    }
}