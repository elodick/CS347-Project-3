using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitGame : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    Scene End;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Exit game
            SceneManager.LoadScene("Victory");
        }
    }
}
