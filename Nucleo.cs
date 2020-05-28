using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nucleo : MonoBehaviour
{
    public float life = 1000f;
    public Light luzLife;
    public Light luzAmarilla;
    public Light luzRoja;
    public ParticleSystem smoke1;
    public ParticleSystem smoke2;

    private void Start()
    {
        smoke1.Stop();
        smoke2.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        if(life > 500f)
        {
            luzLife.enabled = true;
            luzAmarilla.enabled = false;
            luzRoja.enabled = false;
        }
        if(life <= 500f)
        {
            smoke1.Play();
            smoke2.Play();
            luzAmarilla.enabled = true;
            luzLife.enabled = false;
        }
        if(life <= 100f)
        {
            luzRoja.enabled = true;
            luzAmarilla.enabled = false;
        }
    }
}
