using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint2 : MonoBehaviour
{
    PlayerMove playerM;
    HealthBar healthBar;
    Nucleo nucleo;
    // Start is called before the first frame update
    void Start()
    {
        playerM = FindObjectOfType<PlayerMove>();
        healthBar = FindObjectOfType<HealthBar>();
        nucleo = FindObjectOfType<Nucleo>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerM.health <= 0f)
        {
            playerM.lifes -= 1;
            playerM.transform.position = transform.position;
            playerM.health = 100f;
            healthBar.SetHealth(playerM.health);
            nucleo.life = 1000f;
        }
    }
}
