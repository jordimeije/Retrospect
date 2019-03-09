using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToGround : MonoBehaviour {

    public GameObject MaxHeight;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(MaxHeight.transform.position, -transform.up);
        RaycastHit raycastHit;
        bool Didraycasthit;
        LayerMask mask = LayerMask.GetMask("Ground");
        Didraycasthit = Physics.Raycast(ray, out raycastHit, 100f, mask);

        if (Didraycasthit)
            transform.position = raycastHit.point;
    }
}
