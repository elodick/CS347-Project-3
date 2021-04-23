using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        GameObject oldPlayer = GameObject.FindWithTag("player");
        if (oldPlayer != null)
            Destroy(oldPlayer);
    }


    public void PlayGame()
    {
        SceneManager.LoadScene("StarterStage");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
