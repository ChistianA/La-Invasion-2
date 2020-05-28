using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    public Slider slider;
    public PlayerMove playerM;
    public Rifle rifle;
    float xpMele = 0f;
    float xpDist = 0f;
    float xpReina = 0f;
    float xpTotal = 0f;
    public GameObject mensajeLevelUp;
    bool msgComplete = false;


    public SpawnEnemigos enemys;

    private void Update()
    {
        xpMele = enemys.enemigosMuertosMele * 2;
        xpDist = enemys.enemigosMuertosDis * 5;
        xpReina = enemys.enemigosMuertosReina * 10;
        xpTotal = xpMele + xpDist + xpReina;
        SetXP(xpTotal);
        LevelUp();
    }

    public void SetXP(float xp)
    {
        slider.value = xp;
    }

    void LevelUp()
    {
        //Salto ++
        //Velocidad de ataque ++
        // Daño ++
        if(xpTotal >= 100f && msgComplete == false)
        {
            mensajeLevelUp.SetActive(true);
            playerM.jumpSpeed = 35f;
            rifle.fireRate = 12f;
            rifle.damage = 15f;
            msgComplete = true;
            Invoke("LevelUpComplete", 2.5f);
        }
    }

    void LevelUpComplete()
    {
        mensajeLevelUp.SetActive(false);
    }

}
