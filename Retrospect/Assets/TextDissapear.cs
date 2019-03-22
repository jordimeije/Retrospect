using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDissapear : MonoBehaviour {
    public float DissapearanceTime;
    public float Speed;
    public GameObject Player;
    public float MaxDistance;
    bool once = false;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) < MaxDistance && once == false)
        {
            StartCoroutine(Dissapear());
            try
            {
                GetComponent<AudioSource>().Play();
            }
            catch { }
            once = true;
        }
    }

    public IEnumerator Dissapear() {
        yield return new WaitForSecondsRealtime(DissapearanceTime);
        float Progress = 0;
        while (GetComponent<Renderer>().material.GetFloat("_Fragmentation") < 1)
        {
            Progress += Time.deltaTime * Speed;
            GetComponent<Renderer>().material.SetFloat("_Fragmentation", Mathf.Lerp(0, 1, Progress));
            yield return new WaitForSecondsRealtime(Time.deltaTime);
        }
        Destroy(this.gameObject);
    }
}
