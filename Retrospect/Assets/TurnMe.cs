using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMe : MonoBehaviour {
    bool Test;
    Vector3 _Pos;
    Vector3 Pos;
    public Transform Eye;
    public Transform Parent;

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Q))
        {

            Parent.RotateAround(Eye.position, transform.up, -45); 

        }
        else if (Input.GetKeyDown(KeyCode.E))
        {

            Parent.RotateAround(Eye.position, transform.up, 45);

        }
    }
}
