using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyToKeyhole : MonoBehaviour {

    public AudioClip C;
    public GameObject Portal1;
    public GameObject Portal2;
    GameObject Key;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            Key = other.gameObject;
            Portal1.SetActive(true);
            Portal2.SetActive(true);
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
