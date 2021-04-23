using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject Spawn, Enemy, Trigger; 
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
        if(collision.gameObject.CompareTag("Player"))
        {
            GameObject Boss = Instantiate(Enemy);
            Boss.transform.position = Spawn.transform.position;
            Destroy(this.gameObject);
        }
    }
}
