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

    [SerializeField]
    GameObject item, itemSpawn; 
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
            GameObject Spawned_Item = Instantiate(item);
            Spawned_Item.transform.position = itemSpawn.transform.position;

        }
    }
  
}
