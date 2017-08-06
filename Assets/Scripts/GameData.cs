using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameData
{
    // === Public Variables ====
    public int Highscore;

    // === Private Variables ====
    private int currentscore;
    // Achievements
    private int bulletsDestroyed;

    public GameData()
    {
        Highscore = 0;
        Currentscore = 0;
    }

    public int Currentscore
    {
        get
        {
            return currentscore;
        }

        set
        {
            currentscore = value;
            if (currentscore > Highscore)
            {
                Highscore = currentscore;
                GameObject.Find("Highscore").GetComponent<Text>().text = "Highscore: " + SaveLoad.CurrentGameData.Highscore.ToString().PadLeft(6, '0');
            }
        }
    }

    public int BulletsDestroyed
    {
        get
        {
            return bulletsDestroyed;
        }

        set
        {
            bulletsDestroyed = value;
            if (bulletsDestroyed > 1)
            {
                if (Social.localUser.authenticated)
                {
                    Social.Active.ReportProgress(GPGSIds.achievement_tenBulletsDestroyed, 100, (bool success) => { });
                }
            }
        }
    }
}
