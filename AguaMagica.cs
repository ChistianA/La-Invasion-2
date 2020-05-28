using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaMagica : MonoBehaviour
{
    float contador;
    bool contadorGo = false;
    PlayerMove playerS;
    public bool invulnerable = false;
    // Start is called before the first frame update
    void Start()
    {
        playerS = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(contadorGo)
            contador += Time.deltaTime;

        if (contador >= 10f)
        {
            invulnerable = false;
            contador = 0f;
            contadorGo = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            contadorGo = true;
            invulnerable = true;
        }
    }

    void Invulnerable()
    {
        playerS.health = 100f;
    }
}
