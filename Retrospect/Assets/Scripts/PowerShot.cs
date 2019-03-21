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
        public bool Touchable;

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
                        GetComponent<Collider>().enabled = false;
                        Invoke("EnableBoxCollider", 0.1f);
                        transform.parent.GetComponent<Hand>().DetachObject(this.gameObject);
                        GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 3000);
                        Touchable = true;
                        GetComponent<AudioSource>().Play();
                        Invoke("Disabletouchable", 3f);
                    }
                    catch { }
                for (int i = 0; i < Player.instance.handCount; i++)
                {
                    Hand hand = Player.instance.GetHand(i);
                    if (hand.controller != null)
                    {
                        if (hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_A) || hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad))
                        {
                            GetComponent<Collider>().enabled = false;
                            Invoke("EnableBoxCollider", 0.1f);
                            transform.parent.GetComponent<Hand>().DetachObject(this.gameObject);
                            GetComponent<Rigidbody>().AddForce(transform.forward * 3000);
                            Touchable = true;
                            GetComponent<AudioSource>().Play();
                            Invoke("Disabletouchable", 3f);
                        }
                    }
                }
            }
        }

        void EnableBoxCollider()
        {
            GetComponent<Collider>().enabled = true;
        }

        void Disabletouchable()
        {
            Touchable = false;
            this.enabled = false;
        }
    }
}
