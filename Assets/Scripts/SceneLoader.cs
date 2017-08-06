using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    public string scene;

    public void LoadScene()
    {
        SaveLoad.Save();
        UIcontrols.bannerView.Destroy();
        SceneManager.LoadScene(scene);
    }
}
