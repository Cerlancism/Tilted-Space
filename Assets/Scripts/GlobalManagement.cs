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
        Score = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

    public static void ChangeScore(int Value)
    {
        Score = Score + Value;
        GameObject.Find("Score").GetComponent<Text>().text = "SCORE: " + Score.ToString().PadLeft(6, '0');
    }
}
