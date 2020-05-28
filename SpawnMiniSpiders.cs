using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMiniSpiders : MonoBehaviour
{
    DetectorA2 detector2;
    public GameObject miniSpider;
    float contador;
    ActivarOleadas star;
    // Start is called before the first frame update
    void Start()
    {
        detector2 = FindObjectOfType<DetectorA2>();
        star = FindObjectOfType<ActivarOleadas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (star.Startt)
        {
            contador += Time.deltaTime;
            if (detector2.Level2Start == true && contador >= 5.5f)
            {
                Instantiate(miniSpider, transform.position, Quaternion.identity);
                contador = 0f;
            }
        }

    }
}
