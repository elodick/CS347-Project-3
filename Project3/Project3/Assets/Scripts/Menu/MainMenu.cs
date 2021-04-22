using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int minSceneIndex = 1;
    public int maxSceneIndex = 3;
    private static System.Random uniform = new System.Random();

    public void PlayGame()
    {
        SceneManager.LoadScene(uniform.Next(minSceneIndex, maxSceneIndex));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
