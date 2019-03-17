using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Valve.VR.InteractionSystem
{

    [RequireComponent(typeof(Interactable))]
    public class PowerShot : MonoBehaviour
    {
        float WaitTime;
        // Use this for initialization
        void OnEnable() {
            WaitTime = 0;
        }

        // Update is called once per frame
        void Update()
        {
            WaitTime += Time.deltaTime;
            if (WaitTime > 0.1f)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                    try
                    {
                        transform.parent.GetComponent<Hand>().DetachObject(this.gameObject);
                        GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 2000);
                    }
                    catch { }
                for (int i = 0; i < Player.instance.handCount; i++)
                {
                    Hand hand = Player.instance.GetHand(i);
                    if (hand.controller != null)
                    {
                        if (hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_A))
                        {
                            transform.parent.GetComponent<Hand>().DetachObject(this.gameObject);
                            GetComponent<Rigidbody>().AddForce(transform.forward * 2000);
                        }
                    }
                }
            }
        }
    }
}
