using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBarController : MonoBehaviour
{
    public PlayerController player;
    public Image reloadBar;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        reloadBar = GameObject.Find("reloadbar").GetComponent<Image>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer = player.GetComponent<Shoot>().timer;
        reloadBar.fillAmount = timer*100 / 100f;
    }

}
