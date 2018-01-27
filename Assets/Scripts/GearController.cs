using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearController : MonoBehaviour {

    public int gearTeeths;

    public void changeGear(int newSize)
    {
        if(newSize == gearTeeths) {
            return;
        }

        gearTeeths = newSize;

        Mesh newMesh;
        switch (newSize)
        {
            case 8:
                newMesh = Resources.Load("Gear8", typeof(Mesh)) as Mesh;
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

        GetComponent<MeshFilter>().mesh = newMesh;
    }

}
