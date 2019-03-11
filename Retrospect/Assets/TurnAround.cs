using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour {

    public Vector3 TurnAmount;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(TurnAmount * Time.deltaTime);
	}
}
