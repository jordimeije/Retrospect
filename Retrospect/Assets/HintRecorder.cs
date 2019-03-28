        using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HintRecorder : MonoBehaviour
{

    public static int TotalHints;
    public List<Material> Rocks;
    public List<Material> _Rocks;
    public List<GameObject> Hints, NextLevels;
    bool SetRocks;
    int _Level = 0;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < Rocks.Count; i++)
            Rocks[i].SetColor("_EmissionColor", _Rocks[i].GetColor("_EmissionColor"));

    }

    // Update is called once per frame
    void Update()
    {
        if (Ambiance.Level != _Level)
            SetHintsBack();
    }

    void SetHintsBack()
    {
        NextLevels[Ambiance.Level - 1].GetComponent<Toggle>().interactable = false;
        if (Ambiance.Level < NextLevels.Count)
        NextLevels[Ambiance.Level].GetComponent<Toggle>().interactable = true;
        _Level = Ambiance.Level;
    }

    public void SetHintLevel1()
    {
        if (!SetRocks)
        {
            foreach (Material m in Rocks)
                m.SetColor("_EmissionColor", m.GetColor("_EmissionColor") * 4);
            SetRocks = true;
            TotalHints++;
        }
        else
        {
            foreach (Material m in Rocks)
                m.SetColor("_EmissionColor", m.GetColor("_EmissionColor") / 4);
            SetRocks = false;
        } 
    }

    public void GotoLevel2()
    {
        GameObject.FindObjectOfType<CodeGenerater>().NextLevel();
        TotalHints++;
    }
    public void GotoLevel3()
    {
        GameObject.FindObjectOfType<KeyToKeyhole>().NextLevel();
        TotalHints++;
    }

    public void ShowCrystal()
    {
        GameObject.FindObjectOfType<WellAppear>().SetCrystal();
        TotalHints++;
    }

    public void GoToLevel4()
    {
        try
        {
            GameObject.FindObjectOfType<WellAppear>().SetCrystal();
        }
        catch { }

        GameObject.FindObjectOfType<WellAppear>().NextLevel();
        GameObject.FindObjectOfType<WellAppear>().GetComponent<SetLocations>().GoToBelt = true;

        TotalHints++;
    }

    public void GoToEndGame()
    {
        GameObject.FindObjectOfType<Explosion>().Explode();
        TotalHints++;
    }

    public void SetHint(int HintNumber)
    {
        Hints[HintNumber].SetActive(!Hints[HintNumber].activeSelf);
        if (Hints[HintNumber].activeSelf)
        TotalHints++;
    }

    private void OnApplicationQuit()
    {
        for (int i = 0; i < Rocks.Count; i++)
            Rocks[i].SetColor("_EmissionColor", _Rocks[i].GetColor("_EmissionColor"));
    }
}
