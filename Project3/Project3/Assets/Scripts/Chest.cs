using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField]
    public SpriteRenderer spriteRenderer;

    [SerializeField]
    public Sprite closed, open;

    [SerializeField]
    bool IsOpen;

    public int DecideItem; 

    [SerializeField]
    GameObject item, itemSpawn;

    [SerializeField]
    GameObject health, speed, FireRate, damage; 
    // Start is called before the first frame update
    void Start()
    {
        IsOpen = false;
        spriteRenderer.sprite = closed;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && IsOpen ==false)
        {
            IsOpen = true;
            spriteRenderer.sprite = open;
            //Call a function to randomly decide what item to spawn
            item = RandomItem(); 
            GameObject Spawned_Item = Instantiate(item);
            Spawned_Item.transform.position = itemSpawn.transform.position;

        }
    }
  private GameObject RandomItem()
    {
        int x;
       x  = Random.Range(1, 5);
        if(x ==1)
        {
            return health;
        }
        else if (x == 2)
        {
            return speed;
        }
        else if (x == 3)
        {
            return FireRate;
        }
        else 
        {
            return damage;
        }

    }
}
