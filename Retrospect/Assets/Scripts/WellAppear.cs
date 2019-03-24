using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellAppear : MonoBehaviour {

    public GameObject Well;
    bool once;
    public MeshRenderer R, M;
    public GameObject Final;
    public GameObject QuoteOne, QuoteTwo;
	
	// Update is called once per frame
	void Update () {
		if (Well.GetComponent<Animation>()["BucketClimb"].normalizedTime > 0.90f && !once && Ambiance.Level == 2)
        {
            SetCrystal();
            once = true;
        }
	}

    public void NextLevel()
    {
        if (Ambiance.Level >= 3)
            return;

        Final.SetActive(true);
        QuoteOne.SetActive(true);
        QuoteTwo.SetActive(true);
        GameObject.FindObjectOfType<AudioPlayer>().PickedUpGlass(5);
        Ambiance.Level++;
    }

    public void SetCrystal()
    {
        GetComponent<BoxCollider>().enabled = true;
        R.enabled = true;
        M.enabled = true;
    }
}
