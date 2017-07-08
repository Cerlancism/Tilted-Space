using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontrols : MonoBehaviour
{
    public Canvas PauseCanvas;
    public Canvas HowtoplayCanvas;
    public Canvas OptionsCanvas;
    public Canvas CreditsCanvas;
    private bool paused = false;

    //Start button code
    protected void Start()
    {
        PauseCanvas.enabled = false;
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
    public void Menu()
    {
        SceneManager.LoadScene(0);
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
    }

}
