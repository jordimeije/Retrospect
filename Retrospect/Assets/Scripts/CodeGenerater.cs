using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeGenerater : MonoBehaviour {

    public static int CurrentNumber;
    public static bool Isgood = false;

    public static List<int> AllNumbers = new List<int>();
    public List<SpriteRenderer> SpritesHolders;
    public List<Sprite> Sprites;
    public string Numbers;
    public string SavedNumbers;

    public AudioClip Click;
    public AudioClip Unlock;

    public GameObject Screen;

    public GameObject Portal;

    public GameObject SoundPlayer;

    public void Start()
    {

        for(int i = 0; i < Numbers.Length; i++)
        {
            AllNumbers.Add(int.Parse(Numbers.Substring(i, 1)));
        }
        CurrentNumber = 0;
    }

    public void SetNumber(int Num)
    {
        if (Isgood)
            return;

        if (CurrentNumber == 0)
            foreach (SpriteRenderer R in SpritesHolders)
                R.sprite = Sprites[0];
        CurrentNumber++;
        Screen.GetComponent<Text>().text = "";
        SavedNumbers += Num.ToString();
        SpritesHolders[CurrentNumber - 1].sprite = Sprites[Num];
        GetComponent<AudioSource>().clip = Click;
        GetComponent<AudioSource>().Play();

        if (CurrentNumber == AllNumbers.Count)
        {
            for (int i = 0; i < AllNumbers.Count; i++)
            {
                Isgood = AllNumbers[i] == int.Parse(SavedNumbers.Substring(i, 1)) ? true : false;
                if (Isgood == false)
                    break;
            }
            if (!Isgood)
            {
                Screen.GetComponent<Text>().text = "Nope";
                CurrentNumber = 0;
                SavedNumbers = "";
            }
            else
            {
                NextLevel();
            }
        }
    }

    public void NextLevel()
    {
        Screen.GetComponent<Text>().text = "Yay";
        GetComponent<AudioSource>().clip = Unlock;
        GetComponent<AudioSource>().Play();
        Portal.SetActive(true);
        Ambiance.Level++;
        SoundPlayer.GetComponent<AudioPlayer>().GateOpened(6);
    }
}
