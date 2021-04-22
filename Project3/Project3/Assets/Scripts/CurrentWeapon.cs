using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWeapon : MonoBehaviour
{

    public Sprite pistol, shotgun;
    private SpriteRenderer spriteRenderer;
    private int shot;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        shot = player.GetComponent<PlayerController>().shotType;
        if (shot == 0)
            spriteRenderer.sprite = pistol;
        if (shot == 1)
            spriteRenderer.sprite = shotgun;
    }
}
