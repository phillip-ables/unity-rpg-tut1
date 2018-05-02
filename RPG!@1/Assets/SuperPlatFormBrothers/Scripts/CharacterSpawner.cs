using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour {

    public GameObject[] players;

    private void Start()
    {
        if (PlayerPrefs.GetInt("SelectedCharacter") == 0)
            Instantiate(players[(0)], Vector2.zero, Quaternion.identity);
        else
            Instantiate(players[(1)], Vector2.zero, Quaternion.identity);
    }

}
