using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Tutorial_1");
    }

    private void UnloadMenu()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false); // or false
        }
    }

    private void LoadMenu()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true); // or false
        }
    }
}

