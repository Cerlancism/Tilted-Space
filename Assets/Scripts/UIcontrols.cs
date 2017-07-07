using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontrols : MonoBehaviour
{


    public GameObject PauseUI;
    public Canvas HowtoplayCanvas;
    public Canvas OptionsCanvas;
    public Canvas CreditsCanvas;
    private bool paused = false;
    
    //Start button code
    protected void Start()
    {
        HowtoplayCanvas.enabled = false;
        OptionsCanvas.enabled = false;
        CreditsCanvas.enabled = false;
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
    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    //resume button code
    public void Resume()
    {
        paused = false;
    }

    //pause button 
    public void Pause()
    {
        paused = true;
    }

    //Menu button code
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

}
