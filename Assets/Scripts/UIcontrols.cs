using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIcontrols : MonoBehaviour
{
    public Canvas PauseCanvas;
    public Canvas HowtoplayCanvas;
    public Canvas OptionsCanvas;
    public Canvas CreditsCanvas;
    public Canvas DeathCanvas;
    private bool paused = false;
    public bool vibratecheck;

    //Start button code
    protected void Start()
    {
        HowtoplayCanvas.enabled = false;
        try
        {
            GameObject.Find("MasterSlider").GetComponent<Slider>().value = PlayerPrefs.GetFloat("MasterVol");
            GameObject.Find("MusicSlider").GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVol");
            GameObject.Find("SFXSlider").GetComponent<Slider>().value = PlayerPrefs.GetFloat("SFXVol");
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
        OptionsCanvas.enabled = false;
        CreditsCanvas.enabled = false;
        PauseCanvas.enabled = false;
        DeathCanvas.enabled = false;
    }

    public void Startgame()
    {
        SceneManager.LoadScene(1);
    }
    //howtoplay button code
    public void Howtoplay()
    {
        HowtoplayCanvas.enabled = !HowtoplayCanvas.enabled;
    }

    //howtoplay2 button code
    public void Options()
    {
        OptionsCanvas.enabled = !OptionsCanvas.enabled;
    }

    //howtoplay button code
    public void Credits()
    {
        CreditsCanvas.enabled = !CreditsCanvas.enabled;
    }

    //back button code
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    //resume button code
    public void Resume()
    {
        PauseCanvas.enabled = !PauseCanvas.enabled;
        Time.timeScale = 1;
    }

    //back button code
    public void Pause()
    {
        PauseCanvas.enabled = !PauseCanvas.enabled;
    }

    public void VibrateCheck()
    {
        if (GameObject.Find("EnableVibration").GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Vibration", 0);
        }
    }

    // Death code
    public void Die()
    {
        DeathCanvas.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseCanvas.enabled)
        { 
            Time.timeScale = 0;
        }
        
        if (!PauseCanvas.enabled)
        {
            Time.timeScale = 1;
        }

        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            vibratecheck = true;
            GameObject.Find("EnableVibration").GetComponent<Toggle>().isOn = true;
        }
        else
        {
            vibratecheck = false;
            GameObject.Find("EnableVibration").GetComponent<Toggle>().isOn = false;
        }
    }

}
