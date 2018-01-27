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
    public Material highlightMaterial;
    public GameObject targetObject;

    Material targetMaterial;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(OnClick != null)
            OnClick.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetMaterial = targetObject.GetComponent<MeshRenderer>().material;
        targetObject.GetComponent<MeshRenderer>().material = highlightMaterial;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetObject.GetComponent<MeshRenderer>().material = targetMaterial;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
