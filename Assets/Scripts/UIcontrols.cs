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

    public static bool vibratecheck = true;
    public static bool useRoll = false;

    //Start button code
    protected void Start()
    {
        HowtoplayCanvas.enabled = false;
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
        GameObject.Find("MasterSlider").GetComponent<Slider>().value = PlayerPrefs.GetFloat("MasterVol");
        GameObject.Find("MusicSlider").GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVol");
        GameObject.Find("SFXSlider").GetComponent<Slider>().value = PlayerPrefs.GetFloat("SFXVol");
        GameObject.Find("EnableVibration").GetComponent<Toggle>().isOn = vibratecheck ? true : false;
        GameObject.Find("EnableRoll").GetComponent<Toggle>().isOn = useRoll ? true : false;
    }

    //howtoplay button code
    public void Credits()
    {
        CreditsCanvas.enabled = !CreditsCanvas.enabled;
    }

    //back button code
    public void Menu()
    {
        SaveLoad.Save();
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            //TODO: Comfirm quite canvas
            Application.Quit();
        }
        else if (SceneManager.GetActiveScene().name == "Space")
        {
            Pause();
        }
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
            vibratecheck = true;
        }
        else
        {
            PlayerPrefs.SetInt("Vibration", 0);
            vibratecheck = false;
        }
    }

    public void RollCheck()
    {
        if (GameObject.Find("EnableRoll").GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("Roll", 1);
            useRoll = true;
        }
        else
        {
            PlayerPrefs.SetInt("Roll", 0);
            useRoll = false;
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

}
