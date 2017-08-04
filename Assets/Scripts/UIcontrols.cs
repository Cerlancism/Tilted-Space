using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIcontrols : MonoBehaviour
{
    public static BannerView bannerView;
    public static InterstitialAd interstitial;

    public Canvas PauseCanvas;
    public Canvas HowtoplayCanvas;
    public Canvas OptionsCanvas;
    public Canvas CreditsCanvas;
    public Canvas DeathCanvas;

    public static bool vibratecheck = true;
    public static bool useRoll = false;
    public bool extralife;

    //Start button code
    protected void Start()
    {
        Time.timeScale = 1;
        HowtoplayCanvas.enabled = false;
        OptionsCanvas.enabled = false;
        CreditsCanvas.enabled = false;
        PauseCanvas.enabled = false;
        DeathCanvas.enabled = false;
        extralife = false;

        RequestBanner();
        if (SceneManager.GetActiveScene().name == "Space")
        {
            bannerView.Hide();
            RequestInterstitial();
        }
    }

    public void Startgame()
    {
        SceneManager.LoadScene(1);
        bannerView.Hide();
    }
    //howtoplay button code
    public void Howtoplay()
    {
        HowtoplayCanvas.enabled = !HowtoplayCanvas.enabled;
    }

    //options button code
    public void Options()
    {
        OptionsCanvas.enabled = !OptionsCanvas.enabled;
        GameObject.Find("MasterSlider").GetComponent<Slider>().value = PlayerPrefs.GetFloat("MasterVol");
        GameObject.Find("MusicSlider").GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVol");
        GameObject.Find("SFXSlider").GetComponent<Slider>().value = PlayerPrefs.GetFloat("SFXVol");
        GameObject.Find("EnableVibration").GetComponent<Toggle>().isOn = vibratecheck ? true : false;
        GameObject.Find("EnableRoll").GetComponent<Toggle>().isOn = useRoll ? true : false;
    }

    //credits button code
    public void Credits()
    {
        CreditsCanvas.enabled = !CreditsCanvas.enabled;
    }

    //leaderboard button code
    public void Leaderboard()
    {
        Social.Active.ShowLeaderboardUI();
    }

    //back button code
    public void Menu()
    {
        interstitial.Destroy();
        bannerView.Destroy();
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
        bannerView.Show();
    }

    //resume button code
    public void Resume()
    {
        PauseCanvas.enabled = !PauseCanvas.enabled;
        Time.timeScale = 1;
        bannerView.Hide();
    }

    //back button code
    public void Pause()
    {
        PauseCanvas.enabled = !PauseCanvas.enabled;
        if (PauseCanvas.enabled)
        {
            Time.timeScale = 0;
            bannerView.Show();
        }
        else
        {
            Time.timeScale = 1;
            bannerView.Hide();
        }
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
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
            bannerView.Destroy();
        }
    }

    //extra life code 
    public void extraLife()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
            bannerView.Destroy();
        }
        extralife = true;
        DeathCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    private void RequestBanner()
    {
#if UNITY_EDITOR
        string adUnitId = "ca-app-pub-2193747020490389/2344362827";
#elif UNITY_ANDROID
            string adUnitId = "ca-app-pub-2193747020490389/2344362827";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-2193747020490389/2344362827";
#else
            string adUnitId = "ca-app-pub-2193747020490389/8726772496";
#endif
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-2193747020490389/8726772496";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-2193747020490389/8726772496";
#else
        string adUnitId = "ca-app-pub-2193747020490389/8726772496";
#endif
        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }

}
