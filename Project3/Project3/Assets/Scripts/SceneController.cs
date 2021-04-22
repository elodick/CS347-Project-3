using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    private string[] scenes;
    private List<int> scenesTraversed;
    public int minSceneIndex;
    public int maxSceneIndex;
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

        bossNext = false;                
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        scenesTraversed.Add(SceneManager.GetActiveScene().buildIndex);
        if (scenesTraversed.Count >= (maxSceneIndex - minSceneIndex))
            bossNext = true;
        SceneManager.LoadScene(scenes[nextSceneIndex()]);
        GameObject.Find("Player").transform.position = new Vector3(0, 0, -1);
    }

    private int nextSceneIndex()
    {
        int index = Random.Range(minSceneIndex, maxSceneIndex);
        while(scenesTraversed.Contains(index))
            index = Random.Range(minSceneIndex, maxSceneIndex);
        if (bossNext)
            index = 5;
        return index;
    }
}

