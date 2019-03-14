using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLocations : MonoBehaviour {

    public GameObject Belt;
    public GameObject Root;

    public bool HandAttached;
    public bool Inbelt;
    public bool GoToBelt;

    float Speed;
    private void OnTriggerStay(Collider other)
    {
        if (!HandAttached && GoToBelt && !Inbelt && other.tag == "Belt")
            AttachToBelt();
    }

    // Update is called once per frame
    void Update () {
        if (!HandAttached && GoToBelt && !Inbelt && Vector3.Distance(Belt.transform.position, transform.position) > 25)
        {
            AttachToBelt();
        }
        if (HandAttached)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Speed = 75;
            }
            else
                Speed = 30;

            if (Input.GetKey(KeyCode.E))
            {

                transform.Rotate(new Vector3(0, Speed * Time.deltaTime, 0));
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(new Vector3(0, Speed * -Time.deltaTime, 0));
            }
        }
	}

    public void AttachToHand()
    {
        Inbelt = false;
        HandAttached = true;
        GoToBelt = true;
    }

    public void DetachToHand()
    {
        transform.parent = Root.GetComponent<StickToGround>().CurrentGround.transform.root;
        HandAttached = false;
    }

    public void AttachToBelt()
    {
        transform.parent = Belt.transform;
        transform.position = Belt.transform.position;
        Inbelt = true;
    }
}
