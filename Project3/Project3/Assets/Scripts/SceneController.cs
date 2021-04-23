using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    private string[] scenes;
    private List<int> scenesTraversed;
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
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            var drops = GameObject.FindGameObjectsWithTag("drop");
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject drop in drops)
                Destroy(drop);
            foreach (GameObject enemy in enemies)
                Destroy(enemy);
            var curScene = SceneManager.GetActiveScene();
            for (int i = 0; i < 6; i++)
                if (curScene.name.Equals(scenes[i]))
                    SceneManager.LoadScene(scenes[i+1]);
            GameObject.Find("Player").transform.position = new Vector3(0, 0, -1);
        }
    }
}

