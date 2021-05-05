using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Level.LEVEL += 1;
        SceneManager.LoadScene(Level.LEVEL);
        
    }
}

