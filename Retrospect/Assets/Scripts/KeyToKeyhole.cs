using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyToKeyhole : MonoBehaviour {

    public AudioClip C;
    public GameObject Portal1;
    public GameObject Portal2;
    public GameObject Key;
    public GameObject MusicPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            NextLevel();
        }
    }

    public void NextLevel()
    {
        Key.GetComponent<BoxCollider>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Portal1.SetActive(true);
        Portal2.SetActive(true);
        Ambiance.Level++;
        GetComponent<AudioSource>().clip = C;
        GetComponent<AudioSource>().Play();
        MusicPlayer.GetComponent<AudioPlayer>().GateOpened(4);
        try
        {
            transform.parent.GetComponent<Valve.VR.InteractionSystem.Hand>().DetachObject(this.gameObject);
        }
        catch { }
        try
        {
            transform.parent.GetComponent<Valve.VR.InteractionSystem.Hand>().DetachObject(Key.gameObject);
        }
        catch { }

        Invoke("DestroyObjects", C.length);
    }

    void DestroyObjects()
    {
        Key.GetComponent<MeshRenderer>().enabled = false;
       // Destroy(Key);
        Destroy(gameObject);

    }
}
