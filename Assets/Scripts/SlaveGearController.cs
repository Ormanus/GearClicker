using UnityEngine;

public class SlaveGearController : GearController {

    public GameObject masterGear;
    public GameObject beltObject;

    private GearController masterGearController;

    void Start()
    {
        masterGearController = masterGear.GetComponent<GearController>();
    }

    public override void changeGear(int newSize)
    {
        base.changeGear(newSize);
    }

    void LateUpdate()
    {
        // Fetch revolution info from master
        float angleCounter = -masterGearController.getCounter();
        if (angleCounter == 0.0f)
            return;

        // Reset masters counter
        masterGearController.resetCounter();

        // Take gearratio into account, and add opposite rotation to our counter
        float gearRatio = (float)masterGearController.gearTeeths / (float)gearTeeths;
        angleCounter *= gearRatio;
        changeCounter(angleCounter);

        transform.Rotate(new Vector3(0, 0, getCounterDiff() % 360.0f ));

        // If this is the last gear, we need to transfer full rotations to belt
        if(beltObject != null)
        {
            int fullRotations = (int)System.Math.Floor(getCounter() / 360.0f);
            for(int l1=0; l1<fullRotations; l1++)
            {
                beltObject.GetComponent<ConveyorScript>().TickFromGear();
                changeCounter(-360.0f);

            }
        }
    }

}
