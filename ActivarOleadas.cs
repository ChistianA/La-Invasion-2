using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivarOleadas : MonoBehaviour
{
    public GameObject PressE;
    bool PressOn = false;
    public bool Startt = false;
    public Light proyectorL;
    float contador = 4f;
    public Light luzRoja;
    public AudioSource alarma;
    public GameObject msgProgete;
    public GameObject msgBusca;

    // Update is called once per frame
    void Update()
    {
        if (Startt)
        {
            contador -= Time.deltaTime;
            if (contador <= 4f)
            {
                luzRoja.enabled = true;
            }
            if (contador <= 2f)
            {
                luzRoja.enabled = false;
            }
            if (contador <= 0f)
            {
                contador = 4f;
            }
        }

        
        if (Input.GetKeyDown(KeyCode.E) && PressOn == true)
        {
            msgBusca.SetActive(false);
            msgProgete.SetActive(true);
            Invoke("MsgProtegeOk", 2.5f);
            alarma.Play();
            proyectorL.enabled = false;
            luzRoja.enabled = true;
            PressE.SetActive(false);
            Startt = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && Startt == false)
        {
            PressE.SetActive(true);
            PressOn = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PressOn = false;
        PressE.SetActive(false);
    }

    void MsgProtegeOk()
    {
        msgProgete.SetActive(false);
    }
}
