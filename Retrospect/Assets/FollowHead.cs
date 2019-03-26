using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHead : MonoBehaviour {

    public GameObject VRHead;
    public GameObject NormalHead;

	// Use this for initialization
	void Start () {
        if (NormalHead.activeSelf)
            Destroy(this);
	}
	
	// Update is called once per frame
	void Update () {
            Vector3 p = VRHead.transform.localPosition;
            p.y = transform.localPosition.y;
            transform.localPosition = p;
	}
}
