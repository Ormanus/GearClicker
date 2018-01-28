using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearController : MonoBehaviour {

    public int gearTeeths;

    private float angleDiff = 0.0f;
    private float angleCounter = 0.0f;

    public void changeCounter(float amount)
    {
        angleCounter += amount;
        angleDiff += amount;
    }

    public float getCounter()
    {
        return angleCounter;
    }

    public float getCounterDiff()
    {
        float retval = angleDiff;
        angleDiff = 0;
        return (retval);
    }

    public void resetCounter()
    {
        angleCounter = 0.0f;
    }

    public virtual void changeGear(int newSize)
    {
        if(newSize == gearTeeths) {
            return;
        }

        Mesh newMesh;
        switch (newSize)
        {
            case 7:
                newMesh = Resources.Load("Gear7", typeof(Mesh)) as Mesh;
                break;
            case 11:
                newMesh = Resources.Load("Gear11", typeof(Mesh)) as Mesh;
                break;
            case 17:
                newMesh = Resources.Load("Gear17", typeof(Mesh)) as Mesh;
                break;
            default:
                return;
        }

        gearTeeths = newSize;

        // Update mesh & meshcollider
        var mf = GetComponent<MeshFilter>();
        var mc = GetComponent<MeshCollider>();

        mf.mesh = newMesh;

        if(mc != null)
        {
            GetComponent<MeshCollider>().sharedMesh = null;
            GetComponent<MeshCollider>().sharedMesh = mf.mesh;
        }
    }

}
