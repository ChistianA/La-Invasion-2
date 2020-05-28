using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemigos : MonoBehaviour
{
    float contador = 0f, contador2 = 0f, contador3 = 0f;
    public GameObject hijo;
    public GameObject hijo2;
    public GameObject hijo3;
    public bool startGame = false;
    public float gameTime;
    public int enemigosMuertosMele;
    public int enemigosMuertosDis;
    public int enemigosMuertosReina;
    float spawnRate = 2f;
    int randomN = 0;

    void Update()
    {
        randomN = Random.Range(0, 100);
        
        contador += Time.deltaTime;
        contador2 += Time.deltaTime;
        if (startGame == true)
            contador3 += Time.deltaTime;
        if (contador2 >= 15f && spawnRate >= 1.5f)
        {
            spawnRate -= 0.2f;
            contador2 = 0f;
        }
        if (contador >= spawnRate && startGame == true)
        {
            if (randomN <= 60)
            {
                Instantiate(hijo, transform.position, Quaternion.identity);
                contador = 0;
            }else if(randomN <= 90){
                Instantiate(hijo2, transform.position, Quaternion.identity);
                contador = 0f;
            }else if(randomN <= 100)
            {
                Instantiate(hijo3, transform.position, Quaternion.identity);
                contador = 0f;
            }
        }
        
        /*
        contador += Time.deltaTime;
        contador2 += Time.deltaTime;
        contador3 += Time.deltaTime;
        duracionOleada1 += Time.deltaTime;
        if(contador >= 2f && cont11 < 10f && startGame == true)
        {
            Instantiate(hijo, transform.position, Quaternion.identity);
            cont11 += 1f;
            contador = 0f;
        }
        if(contador2 >= 4f && cont11 >= 10f && cont22 < 10f)
        {
            Instantiate(hijo2, transform.position, Quaternion.identity);
            cont22 += 1f;
            contador2 = 0f;
        }
        if(contador3 >= 5f && cont22 >= 10f && con33 < 10f)
        {
            Instantiate(hijo3, transform.position, Quaternion.identity);
            con33 += 1f;
            contador3 = 0f;
        }
        */
    }
}
