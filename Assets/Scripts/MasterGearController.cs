using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGearController : GearController
{

    void Start()
    {
    }

    void Update()
    {
        // Handle click event for the first gear
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, 2), ForceMode.Impulse);

        }
    }

}