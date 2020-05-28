using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsferaDeVida : MonoBehaviour
{
    PlayerMove playerM;
    HealthBar healthBar;
    float curacion = 40f;
    Misiones miss;

    // Start is called before the first frame update
    void Start()
    {
        miss = FindObjectOfType<Misiones>();
        healthBar = FindObjectOfType<HealthBar>();
        playerM = FindObjectOfType<PlayerMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerM.audioCorazon.Play();
            playerM.health += curacion;
            miss.primerCorazon = true;
            healthBar.SetHealth(playerM.health);
            Destroy(gameObject);
        }
    }
}
