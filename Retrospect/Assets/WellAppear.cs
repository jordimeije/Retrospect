using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellAppear : MonoBehaviour {

    public GameObject Well;
    public MeshRenderer R, M;
	
	// Update is called once per frame
	void Update () {
		if (Well.GetComponent<Animation>()["BucketClimb"].normalizedTime > 0.90f)
        {
            GetComponent<BoxCollider>().enabled = true;
            R.enabled = true;
            M.enabled = true;
            Destroy(this);
        }
	}
}
