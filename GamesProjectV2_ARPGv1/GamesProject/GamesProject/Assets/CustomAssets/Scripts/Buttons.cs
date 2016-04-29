using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadScene(String targetScene)
    {
        SceneManager.LoadScene(targetScene);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void NewGame(String targetScene)
    {
        PlayerPrefs.SetInt("Load", 0);
        SceneManager.LoadScene(targetScene);
    }

    public void LoadGame(String targetScene)
    {
        PlayerPrefs.SetInt("Load", 1);
        SceneManager.LoadScene(targetScene);
    }
}
