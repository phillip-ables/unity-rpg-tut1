using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManagement : MonoBehaviour {

    public static DataManagement dataManagement;

    public int highScore;

    private void Awake()
    {
        if ( dataManagement == null)
        {
            DontDestroyOnLoad(gameObject);
            dataManagement = this;
        }
        else if (dataManagement != this)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData ()
    {
        //creates binary formatter
        BinaryFormatter BinForm = new BinaryFormatter();
        //creates file
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");
        //creates container for data
        gameData data = new gameData();
        data.highScore = highScore;
        BinForm.Serialize(file, data);
        file.Close();
    }

    public void LoadData()
    {
        if (File.Exists (Application.persistentDataPath+ "/gameInfo.dat"))
        {
            BinaryFormatter BinForm = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            gameData data = (gameData)BinForm.Deserialize(file);
            file.Close();
            highScore = data.highScore;
        }
    }

}

[Serializable]
class gameData
{
    public int highScore;
}
