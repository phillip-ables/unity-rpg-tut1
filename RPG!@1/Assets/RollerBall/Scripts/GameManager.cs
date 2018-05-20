using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public static GameManager Instance{get{ return instance; } }

    public int currentSkinIndex;
    public uint currecy;
    public uint skinAvalability;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);


    }
}