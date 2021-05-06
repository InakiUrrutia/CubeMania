using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public static int LEVEL = 0;

    public static void loadNextScene()
    {
        if (LEVEL + 1 < SceneManager.sceneCountInBuildSettings)
        {
            LEVEL += 1;
            SceneManager.LoadScene(LEVEL);
        }
        else
        {
            goBackMenu();
        }
    }

    public static void goBackMenu()
    {
        LEVEL = 0;
        SceneManager.LoadScene(LEVEL);
    }


    void OnTriggerEnter()
    {
        StartCoroutine(DelayNextLevel(3));
    }


    IEnumerator DelayNextLevel(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        Level.loadNextScene();

    }

    void Start()
    {
        
    }

    void Update()
    {

    }

}
