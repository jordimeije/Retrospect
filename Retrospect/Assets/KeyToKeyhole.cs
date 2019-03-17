using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyToKeyhole : MonoBehaviour {

    public AudioClip C;
    public GameObject Portal1;
    public GameObject Portal2;
    GameObject Key;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Key" && !GetComponent<SetLocations>().HandAttached)
        {
            Key = other.gameObject;
            Key.GetComponent<BoxCollider>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            Portal1.SetActive(true);
            Portal2.SetActive(true);
            Ambiance.Level++;
            GetComponent<AudioSource>().clip = C;
            GetComponent<AudioSource>().Play();
            Invoke("DestroyObjects", C.length);
        }
    }

    void DestroyObjects()
    {
        Destroy(Key.gameObject);
        Destroy(this.gameObject);
    }
}
