using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasterEgg : MonoBehaviour
{
    float timer;
    float timer2;
    public Text msg1;
    public Text msg2;

    private void Start()
    {
        timer2 = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer > 60f)
        {
            timer2 += Time.deltaTime;
            msg1.color = new Color(255, 255, 255, timer2);
            msg2.color = new Color(255, 255, 255, timer2);
        }
    }
}
