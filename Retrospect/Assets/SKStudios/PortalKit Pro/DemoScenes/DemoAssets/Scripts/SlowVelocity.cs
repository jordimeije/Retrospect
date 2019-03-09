﻿// © 2018, SKStudios LLC. All Rights Reserved.
// 
// The software, artwork and data, both as individual files and as a complete software package known as 'PortalKit Pro', 
// without regard to source or channel of acquisition, are bound by the terms and conditions set forth in the Unity Asset 
// Store license agreement in addition to the following terms;
// 
// One license per seat is required for Companies, teams, studios or collaborations using PortalKit Pro that have over 
// 10 members or that make more than $50,000 USD per year. 
// 
// Addendum;
// If PortalKitPro constitutes a major portion of your game's mechanics, please consider crediting the software and/or SKStudios.
// You are in no way obligated to do so, but it would be sincerely appreciated.

using SKStudios.Common.Demos;
using UnityEngine;

namespace SKStudios.Portals.Demos {
    public class SlowVelocity : MonoBehaviour {
        public float SlowFactor = 0.995f;

        private void OnTriggerEnter(Collider col)
        {
            BasicFPSExample controller;
            if (controller = col.GetComponent<BasicFPSExample>()) {
                //controller.KillInput = true;
                var rb = col.attachedRigidbody;
                //rb.useGravity = false;
            }
        }

        private void OnTriggerStay(Collider col)
        {
            var rb = col.attachedRigidbody;
            if (rb)
                rb.velocity *= SlowFactor;
        }
    }
}