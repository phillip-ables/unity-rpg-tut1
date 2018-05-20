using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public static GameManager Instance{get{ return instance; } }

    public int currentSkinIndex;
    public uint currency;
    public uint skinAvalability;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (PlayerPrefs.HasKey("CurrentSkin"))
        {

        }
        else
        {
            //if weve never played these are our starting stats
            PlayerPrefs.SetInt("CurrentSkin", 0);
            PlayerPrefs.SetInt("Currency", 0);
            PlayerPrefs.SetInt("SkinAvilability", 1);
        }
    }
}