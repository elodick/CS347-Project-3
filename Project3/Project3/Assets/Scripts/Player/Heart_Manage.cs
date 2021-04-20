using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart_Manage : MonoBehaviour
{
    //Health points
    [SerializeField]
    public int Health;

    [SerializeField] //Current max health
    public int MaxHealth;

    //Hearts to display
    [SerializeField]
    public int Hearts;

    [SerializeField]
    GameObject Player;

    //Array of Heart Images
    public Image[] HeartList;

    //Full Heart Sprite
    [SerializeField]
    public Sprite Full;

    //Empty Heart sprite
    [SerializeField]
    public Sprite Empty;

    // Start is called before the first frame update
    void Start()
    {
       // Player = gameObject.transform.parent.gameObject;
        Health = Player.GetComponent<PlayerController>().health;
        MaxHealth = Player.GetComponent<PlayerController>().MaxHealth; 
        Hearts = Health; 
    }

    // Update is called once per frame
    void Update()
    {
        // Continuously update player's current health status
        //Health = Player.GetComponent<PlayerMovementDylan>().Health; //This may be removed
        Hearts = Health;
        Health = Player.GetComponent<PlayerController>().health;
        MaxHealth = Player.GetComponent<PlayerController>().MaxHealth;
        for (int i = 0; i < HeartList.Length; i++)
        {

            if(i<=Health)
            {
                HeartList[i].sprite = Full;
            }
            if(i>Health)
            {
                HeartList[i].sprite = Empty;
            }
            if(i> MaxHealth-1)
            {
                HeartList[i].gameObject.GetComponent<Renderer>().enabled = false;
            }

       /*
            if (i < Hearts)
            {
                HeartList[i].enabled = true;
            }
            else
            {
                HeartList[i].enabled = false;
            }
       */
            
        }

    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Health--; 
        }
    }
    */
}
