using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeRecorder : MonoBehaviour
{
    string[] LevelTime = new string[4];
    public float StartTime;
    float CurrentTime;

    private void Start()
    {
        StartTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if (Ambiance.Level < 5)
        CurrentTime = Mathf.Round((Time.realtimeSinceStartup - StartTime));


        string T = string.Format("{0}:{1}", Mathf.Floor(CurrentTime / 60).ToString("00"), (CurrentTime % 60).ToString("00"));

        if(Ambiance.Level < 4)
        LevelTime[Ambiance.Level] = T;

        GetComponent<Text>().text = string.Format("Total time: {0}\nLevel 1: {1}\nLevel 2: {2}\nLevel 3: {3}\nLevel 4: {4}\nHints used: {5}", T, LevelTime[0], LevelTime[1], LevelTime[2], LevelTime[3], HintRecorder.TotalHints);
    }
}
