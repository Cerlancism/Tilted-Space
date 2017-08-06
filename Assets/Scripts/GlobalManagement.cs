﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;

public class GlobalManagement : MonoBehaviour
{

    // === Public Variables ====
    public AudioMixer Master;

    // === Private Variables ====


    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        SaveLoad.Load();
        SaveLoad.CurrentGameData.Currentscore = 0;
        SaveLoad.CurrentGameData.BulletsDestroyed = 0;
        GameObject.Find("Highscore").GetComponent<Text>().text = "Highscore: " + SaveLoad.CurrentGameData.Highscore.ToString().PadLeft(6, '0');

        if (PlayerPrefs.HasKey("MasterVol"))
        {
            Master.SetFloat("MasterVol", PlayerPrefs.GetFloat("MasterVol"));
            Master.SetFloat("MusicVol", PlayerPrefs.GetFloat("MusicVol"));
            Master.SetFloat("SFXVol", PlayerPrefs.GetFloat("SFXVol"));
            UIcontrols.vibratecheck = PlayerPrefs.GetInt("Vibration") == 1 ? true : false;
            UIcontrols.useRoll = PlayerPrefs.GetInt("Roll") == 1 ? true : false;
        }
        else
        {
            Camera.main.GetComponent<UIcontrols>().ResetOptions();
        }

        StartPlayGames();
    }

    private void StartPlayGames()
    {
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) => { });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void ChangeScore(int Value)
    {
        SaveLoad.CurrentGameData.Currentscore = SaveLoad.CurrentGameData.Currentscore + Value;
        GameObject.Find("Score").GetComponent<Text>().text = "SCORE: " + SaveLoad.CurrentGameData.Currentscore.ToString().PadLeft(6, '0');
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
