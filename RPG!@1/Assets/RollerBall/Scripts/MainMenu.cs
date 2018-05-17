using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject shopButtonPrefab;
    public GameObject shopButtonContainer;
    public GameObject levelButtonPrefab;
    public GameObject levelButtonContainer;
    private const float CAMERA_TRANSITION_SPEED = 3.0f;

    private Transform cameraTransform;
    private Transform cameraDesiredLook;
    

    private void Start()
    {
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

        Sprite[] textures = Resources.LoadAll<Sprite>("Players");
        foreach (Sprite texture in textures)
        {
            GameObject container = Instantiate(shopButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = texture;
            container.transform.SetParent(shopButtonContainer.transform, false);
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

}
