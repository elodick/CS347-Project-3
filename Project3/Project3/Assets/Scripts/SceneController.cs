using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    private string[] scenes;
    private int[] scenesTraversed;
    public int minSceneIndex;
    public int maxSceneIndex;
    private int currentRun;
    public bool bossNext;

    // Start is called before the first frame update
    void Start()
    {
        scenes = new string[6];
        scenes[0] = "Menu";
        scenes[1] = "StarterStage";
        scenes[2] = "Stage1_1";
        scenes[3] = "Stage1_2";
        scenes[4] = "Stage2_1";
        scenes[5] = "BossStage";
        minSceneIndex = 2;
        maxSceneIndex = 4;
        scenesTraversed = new int[3];
        bossNext = false;
        currentRun = 0;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            var drops = GameObject.FindGameObjectsWithTag("drop");
            foreach (GameObject drop in drops)
                Destroy(drop);
            scenesTraversed[currentRun] = SceneManager.GetActiveScene().buildIndex;
            currentRun++;
            SceneManager.LoadScene(NextSceneIndex());
            GameObject.Find("Player").transform.position = new Vector3(0, 0, -1);
        }
    }

    private int NextSceneIndex()
    {
        int index = Random.Range(minSceneIndex, maxSceneIndex);
        foreach (int i in scenesTraversed)
        {
            if (i == index)
                Random.Range(minSceneIndex, maxSceneIndex);
        }
            if (bossNext)
            index = 5;
        return index;
    }
}

