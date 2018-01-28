using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class OilMeter : MonoBehaviour
{
    Image img;
    public Rigidbody gear;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    void Update ()
    {
        float drag = gear.angularDrag;
        img.fillAmount = 1 - (drag - 1.0f);
    }
}
