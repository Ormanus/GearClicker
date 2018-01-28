using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public Text CostText;
    public Material highlightMaterial;
    public GameObject targetObject;
    public PlayerController playerController;
    public int cost;

    Material targetMaterial;

    public void OnPointerClick(PointerEventData eventData)
    {
        action();
        CostText.text = "Cost: " + cost;
        GetComponent<Image>().color = new Color(0.75f, 0.75f, 0.75f);
    }

    public virtual void action()
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        CostText.text = "Cost: " + cost;

        targetMaterial = targetObject.GetComponent<MeshRenderer>().material;
        targetObject.GetComponent<MeshRenderer>().material = highlightMaterial;

        GetComponent<Image>().color = new Color(0.75f, 0.75f, 0.75f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ResetTarget();
    }

    public void ResetTarget()
    {
        CostText.text = "";

        targetObject.GetComponent<MeshRenderer>().material = targetMaterial;

        GetComponent<Image>().color = Color.white;
    } 

    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<Image>().color = Color.grey;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Image>().color = new Color(0.75f, 0.75f, 0.75f);
    }
}
