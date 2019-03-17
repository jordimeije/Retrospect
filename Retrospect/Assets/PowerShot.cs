using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerShot : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            try
            {
                transform.parent.GetComponent<Valve.VR.InteractionSystem.Hand>().DetachObject(this.gameObject);
                GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 2000);
            }
            catch { }
        print(Valve.VR.EVRButtonId.k_EButton_Grip);
    }
}
