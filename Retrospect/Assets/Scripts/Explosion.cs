using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public GameObject Particle;
    public int TotalHits;
    public GameObject Portal;
    public GameObject Sounds;
    public GameObject Eye;

    // Use this for initialization
    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Floater" && col.transform.GetComponent<Valve.VR.InteractionSystem.PowerShot>().Touchable)
        {
            Particle.GetComponent<ParticleSystem>().Play();
            col.transform.GetComponent<Valve.VR.InteractionSystem.PowerShot>().Touchable = false;
            Destroy(col.gameObject);
            GetComponent<AudioSource>().Play();
            TotalHits++;
            StartCoroutine(Shrink());
            if (TotalHits >= 3)
            {
                Explode();
            }
        }
    }

    public void Explode()
    {
        Portal.SetActive(true);
        Sounds.GetComponent<AudioPlayer>().GateOpened(8);
        Ambiance.Level++;
        Invoke("DestroyMe", 3f);
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }

    public IEnumerator Shrink()
    {
        float CurrentValue = 0;
        float Speed = 1f;
        Vector3 BoxSize = GetComponent<BoxCollider>().size;
        Vector3 _BoxSize = new Vector3(BoxSize.x, BoxSize.y / 1.2f, BoxSize.z / 1.2f);
        Vector3 EyeSize = Eye.transform.localScale;
        Vector3 _EyeSize = new Vector3(EyeSize.x, EyeSize.y / 1.2f, EyeSize.z / 1.2f);
        while (CurrentValue < 1)
        {
            GetComponent<BoxCollider>().size = Vector3.Lerp(BoxSize, _BoxSize, CurrentValue);
            Eye.transform.localScale = Vector3.Lerp(EyeSize, _EyeSize, CurrentValue);
            CurrentValue += Time.deltaTime * Speed;
            yield return new WaitForSecondsRealtime(0.1f);
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
