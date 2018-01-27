using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {

    public Transform target;
    Vector3 offset;

    private void Awake()
    {
        offset = transform.position - target.position;
        gameObject.SetActive(false);
    }

	void Update () {
        transform.position = target.transform.position + offset;
	}
}
