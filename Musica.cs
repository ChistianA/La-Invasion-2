using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Musica : MonoBehaviour
{
    public AudioSource musica1;
    public AudioSource musica2;
    public AudioSource musica3;
    public SpawnEnemigos spawn;
    public Slider sliderVolume;
    bool playOn = false;

    // Update is called once per frame
    void Update()
    {
        if(spawn.startGame == true && playOn == false)
        {
            musica2.Play();
            playOn = true;
            musica1.enabled = false;
        }
    }
    public void VolumenMusica()
    {
        musica1.volume = sliderVolume.value;
        musica2.volume = sliderVolume.value;
        musica3.volume = sliderVolume.value;
    }
}
