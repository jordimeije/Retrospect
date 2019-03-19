using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public GameObject Particle;
    public int TotalHits;
    public GameObject Portal;
    public GameObject Sounds;

    // Use this for initialization
    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Floater" && col.transform.GetComponent<Valve.VR.InteractionSystem.PowerShot>().Touchable)
        {
            Particle.GetComponent<ParticleSystem>().Play();
            Destroy(col.gameObject);
            GetComponent<AudioSource>().Play();
            TotalHits++;
            if (TotalHits >= 3)
            {
                Portal.SetActive(true);
                Sounds.GetComponent<AudioPlayer>().GateOpened(8);
            }
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
