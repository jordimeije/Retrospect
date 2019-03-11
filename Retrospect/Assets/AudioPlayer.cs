using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    public List<AudioClip> AudioFiles;
    public int Songs;
    public int RewindSongs;
    public float OriginalVolume;

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
            Invoke("PlayNew", 5f);
        }

    }

    void PlayNew()
    {
        Songs = (Songs + 1) % RewindSongs;
        GetComponent<AudioSource>().clip = AudioFiles[Songs];
        GetComponent<AudioSource>().Play();
    }

    public void GateOpened()
    {
        StartCoroutine("ChangeNumber");
    }

    public IEnumerator ChangeNumber()
    {
        while (GetComponent<AudioSource>().volume > 0.01)
        {
            GetComponent<AudioSource>().volume -= Time.deltaTime;
            yield return new WaitForSecondsRealtime(Time.deltaTime);
        }

        GetComponent<AudioSource>().clip = AudioFiles[6];
        GetComponent<AudioSource>().Play();

        while (GetComponent<AudioSource>().volume < OriginalVolume)
        {
            GetComponent<AudioSource>().volume += Time.deltaTime;
            yield return new WaitForSecondsRealtime(Time.deltaTime);
        }
        RewindSongs++;
    }
}
