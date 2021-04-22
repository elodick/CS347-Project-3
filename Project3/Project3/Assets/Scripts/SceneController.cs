using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    private string[] scenes;
    private int nextSceneIndex;
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

        nextSceneIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        nextSceneIndex++;
        SceneManager.LoadScene(scenes[nextSceneIndex]);
        GameObject.Find("Player").transform.position = new Vector3(0, 0, -1);
    }
}
