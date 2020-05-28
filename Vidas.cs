using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vidas : MonoBehaviour
{
    public Image life1;
    public Image life2;
    public Image life3;
    public PlayerMove playerM;


    // Update is called once per frame
    void Update()
    {
        if(playerM.lifes == 2)
        {
            life1.color = new Color(0, 0, 0);
        }
        if(playerM.lifes == 1)
        {
            life2.color = new Color(0, 0, 0);
        }
        if(playerM.lifes == 0)
        {
            life3.color = new Color(0, 0, 0);
        }
    }
}
