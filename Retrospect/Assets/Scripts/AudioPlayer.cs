using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    public List<AudioClip> AudioFiles;
    public int Songs = 0;
    public int RewindSongs;
    public float OriginalVolume;
    bool once = false;

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().clip = AudioFiles[0];
        GetComponent<AudioSource>().Play();
        OriginalVolume = GetComponent<AudioSource>().volume;
	}
	
	// Update is called once per frame
	void Update () {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            if (!IsInvoking("PlayNew"))
            Invoke("PlayNew", 5f);
        }
    }

    void PlayNew()
    {
        Songs = (Songs + 1) % RewindSongs;
        GetComponent<AudioSource>().clip = AudioFiles[Songs];
        GetComponent<AudioSource>().Play();
    }

    public void GateOpened(int i)
    {
        StartCoroutine(ChangeNumber(i));
    }

    public void PickedUpGlass(int i)
    {
        if (once == false)
        {
            StartCoroutine(ChangeNumber(i));
            once = true;
        }
    }

    public IEnumerator ChangeNumber(int i)
    {
        while (GetComponent<AudioSource>().volume > 0.01)
        {
            GetComponent<AudioSource>().volume -= Time.deltaTime / 5;
            yield return new WaitForSecondsRealtime(Time.deltaTime);
        }

        GetComponent<AudioSource>().clip = AudioFiles[i];
        GetComponent<AudioSource>().Play();

        while (GetComponent<AudioSource>().volume < OriginalVolume)
        {
            GetComponent<AudioSource>().volume += Time.deltaTime;
            yield return new WaitForSecondsRealtime(Time.deltaTime);
        }
        RewindSongs++;
    }
}
