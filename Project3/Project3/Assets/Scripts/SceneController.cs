using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public string nextScene;
    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        Destroy(player.GetComponent<PlayerController>().invincibleShield);
        SceneManager.LoadScene(nextScene);
    }
}
