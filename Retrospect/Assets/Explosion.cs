using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public GameObject Particle;

    // Use this for initialization
    private void OnCollisionEnter(Collision col)
    {
        print(col.transform.tag);
        if (col.transform.tag == "Floater" && col.transform.GetComponent<Valve.VR.InteractionSystem.PowerShot>().Touchable)
        {
            Particle.GetComponent<ParticleSystem>().Play();
            Destroy(col.gameObject);
            GetComponent<AudioSource>().Play();
        }
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Particle.GetComponent<ParticleSystem>().Play();
            GetComponent<AudioSource>().Play();
        }
    }*/
}
