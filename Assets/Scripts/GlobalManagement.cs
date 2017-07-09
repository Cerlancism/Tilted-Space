using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GlobalManagement : MonoBehaviour
{

    // === Public Variables ====
    public static int Score = 0;
    public static int HighScore;
    public AudioMixer Master;

    // === Private Variables ====



    // Use this for initialization
    void Start()
    {
        Score = 0;
        if (PlayerPrefs.HasKey("Highscore"))
        {
            HighScore = PlayerPrefs.GetInt("Highscore");
            GameObject.Find("Highscore").GetComponent<Text>().text = "Highscore: " + HighScore.ToString().PadLeft(6, '0');
        }
        if (PlayerPrefs.HasKey("MasterVol"))
        {
            PlayerPrefs.GetFloat("MasterVol");
            PlayerPrefs.GetFloat("MusicVol");
            PlayerPrefs.GetFloat("SFXVol");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Score > HighScore)
        {
            HighScore = Score;
            GameObject.Find("Highscore").GetComponent<Text>().text = "Highscore: " + Score.ToString().PadLeft(6, '0');
            PlayerPrefs.SetInt("Highscore", Score);
        }

    }

    public static void ChangeScore(int Value)
    {
        Score = Score + Value;
        GameObject.Find("Score").GetComponent<Text>().text = "SCORE: " + Score.ToString().PadLeft(6, '0');
    }

    public void SetMasterlvl(float Masterlvl)
    {
        Master.SetFloat("MasterVol", Masterlvl);
        PlayerPrefs.SetFloat("MasterVol", Masterlvl);
        PlayerPrefs.Save();
    }

    public void SetMusiclvl(float Musiclvl)
    {
        Master.SetFloat("MusicVol", Musiclvl);
        PlayerPrefs.SetFloat("MusicVol", Musiclvl);
        PlayerPrefs.Save();
    }

    public void SetSFXlvl(float SFXlvl)
    {
        Master.SetFloat("SFXVol", SFXlvl);
        PlayerPrefs.SetFloat("SFXVol", SFXlvl);
        PlayerPrefs.Save();
    }

}
