﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    private const float CAMERA_TRANSITION_SPEED = 3.0f;

    public GameObject shopButtonPrefab;
    public GameObject shopButtonContainer;
    public GameObject levelButtonPrefab;
    public GameObject levelButtonContainer;

    public Material playerMaterial;

    private Transform cameraTransform;
    private Transform cameraDesiredLook;

    

    private void Start()
    {
        ChangePlayerSkin(12);
        cameraTransform = Camera.main.transform;

        Sprite[] thumbnails = Resources.LoadAll<Sprite>("Levels");
        foreach (Sprite thumbnail in thumbnails)
        {
            GameObject container = Instantiate(levelButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = thumbnail;
            container.transform.SetParent(levelButtonContainer.transform, false);

            string sceneName = thumbnail.name;
            container.GetComponent<Button>().onClick.AddListener (() => LoadLevel(sceneName));
        }

        int textureIndex = 0;

        Sprite[] textures = Resources.LoadAll<Sprite>("Players");
        foreach (Sprite texture in textures)
        {
            GameObject container = Instantiate(shopButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = texture;
            container.transform.SetParent(shopButtonContainer.transform, false);

            int index = textureIndex;

            container.GetComponent<Button>().onClick.AddListener(() => ChangePlayerSkin(index));
            textureIndex++;
        }
    }

    private void Update()
    {
        if (cameraDesiredLook != null)
        {
            cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, cameraDesiredLook.rotation, CAMERA_TRANSITION_SPEED * Time.deltaTime);
        }
    }

    private void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LookAtMenu(Transform menuTransform)
    {
        cameraDesiredLook = menuTransform;
        //Camera.main.transform.LookAt(menuTransform.position);
    }

    private void ChangePlayerSkin(int index)
    {
        float x = (index % 4) * 0.25f;
        float y = ((int)index / 4) * 0.25f;

        if (y == 0.0f)
            y = .75f;
        else if (y == 0.25f)
            y = .5f;
        else if (y == .5f)
            y = .25f;
        else if (y == 0.75f)
            y = 0.25f;

            playerMaterial.SetTextureOffset("_MainTex", new Vector2(x, y));
    }

}
