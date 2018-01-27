using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public UnityEvent OnClick;
    public Text CostText;
    public Material highlightMaterial;
    public GameObject targetObject;
    public PlayerController playerController;
    public int cost;

    Material targetMaterial;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(playerController.money >= cost)
        {
            playerController.addMoney(-cost);
            if (OnClick != null)
            {
                OnClick.Invoke();
                cost *= 2;
            }
        }
        CostText.text = "Cost: " + cost;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        CostText.text = "Cost: " + cost;

        targetMaterial = targetObject.GetComponent<MeshRenderer>().material;
        targetObject.GetComponent<MeshRenderer>().material = highlightMaterial;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CostText.text = "";

        targetObject.GetComponent<MeshRenderer>().material = targetMaterial;
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
