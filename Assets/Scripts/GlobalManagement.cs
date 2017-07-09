using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalManagement : MonoBehaviour {

    // === Public Variables ====
    public static int Score = 0;
    public static int HighScore;
	
	
	// === Private Variables ====
	
	
	
	// Use this for initialization
	void Start () 
	{
        if (PlayerPrefs.HasKey("Highscore"))
        {
            HighScore = PlayerPrefs.GetInt("Highscore");
            GameObject.Find("Highscore").GetComponent<Text>().text = "Highscore: " + HighScore.ToString().PadLeft(6, '0');
        }

    }

    // Update is called once per frame
    void Update () 
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
}
