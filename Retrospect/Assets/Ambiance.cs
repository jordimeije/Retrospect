using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambiance : MonoBehaviour
{

    public GameObject[] Cubes;
    public List<Light> Lights;
    public List<Material> GlowObjects;
    public List<Material> OldValues;
    public static int Level;
    int _Level;

    // Use this for initialization
    void Start()
    {
        Cubes = GameObject.FindGameObjectsWithTag("Floater");
        foreach (GameObject C in Cubes)
            C.SetActive(false);

        for (int i = 0; i < Mathf.Floor(Cubes.Length / 4); i++)
        {
            Cubes[i].SetActive(true);
        }
        RenderSettings.skybox.SetFloat("_Exposure", 0.5f);
        for (int i = 0; i < GlowObjects.Count; i++)
        {
            GlowObjects[i].SetColor("_EmissionColor", OldValues[i].GetColor("_EmissionColor"));
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (_Level != Level)
        {
            print(Level);
            switch (Level)
            {
                case 1:
                    for (int i = (int)Mathf.Floor(Cubes.Length / 4); i < Mathf.Floor(Cubes.Length / 4) * 2; i++)
                    {
                        Cubes[i].SetActive(true);
                    }
                    foreach (Light L in Lights)
                    {
                        //L.intensity /= 1.2f;
                        StartCoroutine(ChangeLighting(L.intensity, L.intensity / 1.2f, L));
                    }
                    foreach (Material L in GlowObjects)
                    {
                        StartCoroutine(ChangeColor(L.GetColor("_EmissionColor"), L.GetColor("_EmissionColor") / 1.2f, L));
                    }
                    break;
                case 2:
                    for (int i = (int)Mathf.Floor(Cubes.Length / 4) * 2; i < Mathf.Floor(Cubes.Length / 4) * 3; i++)
                    {
                        Cubes[i].SetActive(true);
                    }
                    foreach (Light L in Lights)
                    {
                        StartCoroutine(ChangeLighting(L.intensity, L.intensity / 1.2f, L));
                    }
                    foreach (Material L in GlowObjects)
                    {
                        StartCoroutine(ChangeColor(L.GetColor("_EmissionColor"), L.GetColor("_EmissionColor") / 1.4f, L));
                    }
                    break;
                case 3:
                    for (int i = (int)Mathf.Floor(Cubes.Length / 4) * 3; i < Cubes.Length; i++)
                    {
                        Cubes[i].SetActive(true);
                    }
                    foreach (Light L in Lights)
                    {
                        StartCoroutine(ChangeLighting(L.intensity, L.intensity / 1.2f, L));
                    }
                    foreach (Material L in GlowObjects)
                    {
                        StartCoroutine(ChangeColor(L.GetColor("_EmissionColor"), L.GetColor("_EmissionColor") / 10f, L));
                    }
                    break;
            }
            _Level = Level;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Level++;
        }
    }

    IEnumerator ChangeLighting(float OldValue, float NewValue, Light LightToChange)
    {
        float CurrentValue = 0;
        float Speed = 2f;
        while (CurrentValue < 1)
        {
            print(CurrentValue);
            LightToChange.intensity = Mathf.Lerp(OldValue, NewValue, CurrentValue);
            CurrentValue += Time.deltaTime * Speed;
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
    IEnumerator ChangeColor(Color OldValue, Color NewValue, Material L)
    {
        float CurrentValue = 0;
        float Speed = 2f;
        while (CurrentValue < 1)
        {
            Color c = L.GetColor("_EmissionColor");
            c.a = Mathf.Lerp(OldValue.a, NewValue.a, CurrentValue);
            c.b = Mathf.Lerp(OldValue.b, NewValue.b, CurrentValue);
            c.g = Mathf.Lerp(OldValue.g, NewValue.g, CurrentValue);
            c.r = Mathf.Lerp(OldValue.r, NewValue.r, CurrentValue);
            L.SetColor("_EmissionColor", c);
            CurrentValue += Time.deltaTime * Speed;
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }


    private void OnApplicationQuit()
    {
        for (int i = 0; i < GlowObjects.Count; i++)
        {
            GlowObjects[i].SetColor("_EmissionColor", OldValues[i].GetColor("_EmissionColor"));
        }
    }
}
