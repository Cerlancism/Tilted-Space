using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;


public static class SaveLoad
{
    // === Public Variables ====
    public static GameData CurrentGameData = new GameData();

    // === Private Variables ====


    // Save is called when scene change or back to menu
    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream gamedata = File.Create(Application.persistentDataPath + "/gamedata.gd");
        bf.Serialize(gamedata, CurrentGameData);
        gamedata.Close();
    }

    // Load is called by global manager
    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/gamedata.gd"))
        {
            Debug.Log("Loaded gamedata from file Path: " + Application.persistentDataPath + "/gamedata.gd");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream gamedata = File.Open(Application.persistentDataPath + "/gamedata.gd", FileMode.Open);
            CurrentGameData = (GameData)bf.Deserialize(gamedata);
            gamedata.Close();
        }
    }
}
