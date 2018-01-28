using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    public Rigidbody gear;
    public Canvas MenuUI;

    private void Update()
    {
        Plane plane = new Plane(Vector3.forward, transform.position);

        float dist;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out dist))
        {
            Vector3 point = ray.GetPoint(dist);

            transform.position = point;
        }

        if(Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
            gear.angularDrag = Mathf.Max(gear.angularDrag - 0.5f, 1.0f);
            MenuUI.enabled = true;
        }
    }
}
