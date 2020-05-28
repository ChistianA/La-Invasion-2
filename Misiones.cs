using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Misiones : MonoBehaviour
{
    public GameObject Mision01;
    public GameObject Mision02;
    public GameObject Mision03;

    public GameObject TutoMove;
    public GameObject TutoJump;
    public GameObject TutoShoot;

    public Image TutoMoveImage;
    public Image TutoJumpImage;
    public Image TutoShootImage;
    public GameObject bienHecho;

    Tutorial totorial;

    bool TutoMoveOK = false;
    bool TutoJumpOK = false;
    bool TutoShootOK = false;

    bool Tuto1Bye = false;
    bool Tuto2Bye = false;
    bool Tuto3Bye = false;

    public bool openDoor = false;

    public Text Mision2Contador;
    public Image Mision1Image;
    public Image Mision2Image;
    public Image Mision3Image;
    SpawnEnemigos start;
    PlayerMove playerM;
    bool misionComplete = false;
    bool mision1Bye = false;
    bool mision2Bye = false;
    bool misionComplete2 = false;
    bool misionComplete3 = false;
    float contador2 = 10f;
    public bool primerCorazon;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        totorial = FindObjectOfType<Tutorial>();
        start = FindObjectOfType<SpawnEnemigos>();
        playerM = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (misionComplete == true)
        {
            Invoke("MisionComplete1", 2.5f);

        }

        if(start.startGame == true && playerM.health == 100f && mision1Bye == true)
        {
            contador2 -= Time.deltaTime;
        }
        else
        {
            contador2 = 10f;
        }
        if(contador2 <= 0f && misionComplete2 == true)
        {
            contador2 = 0f;
        }
        Mision1();
        Mision2();
        Mision3();

        TutoMove1();
        TutoJump1();
        TutoShoot1();

        if (TutoMoveOK)
        {
            Invoke("TutoMoveComplete", 2.5f);
        }
        if (TutoJumpOK)
        {
            Invoke("TutoJumpComplete", 2.5f);
        }
        if (TutoShootOK)
        {
            Invoke("TutoShootComplete", 2.5f);
        }

        if (misionComplete2 == true)
        {
            Invoke("MisionComplete2", 2.5f);
        }
        if(misionComplete3 == true)
        {
            Invoke("MisionComplete3", 2.5f);
        }
    }
    void Mision1()
    {
        if(start.startGame == true && misionComplete == false)
        {
            Mision01.SetActive(true);
            if(start.enemigosMuertosMele == 5)
            {
                misionComplete = true;
                Mision1Image.color = new Color(0,255,0);
            }
        }
    }
    
    void Mision2()
    {
        if(start.startGame == true && mision1Bye == true && misionComplete2 == false)
        {
            Mision02.SetActive(true);
            Mision2Contador.text = "mantente full vida por " + Mathf.Round(contador2) + " segundos";
            if (playerM.health == 100f && contador2 <= 0f)
            {
                misionComplete2 = true;
                Mision2Image.color = new Color(0, 255, 0);
            }
        }

    }
     void Mision3()
    {
        if(mision2Bye == true && misionComplete3 == false)
        {
            Mision03.SetActive(true);
            if(primerCorazon == true)
            {
                misionComplete3 = true;
                Mision3Image.color = new Color(0, 255, 0);
            }

        }
    }

    void TutoMove1()
    {
        if (totorial.gameStats && TutoMoveOK == false)
        {
            TutoMove.SetActive(true);
            if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
            {
                TutoMoveOK = true;
                TutoMoveImage.color = new Color(0, 255, 0);
            }
        }
    }

    void TutoJump1()
    {
        if(totorial.gameStats && TutoJumpOK == false && Tuto1Bye == true)
        {
            TutoJump.SetActive(true);
            if (Input.GetButtonDown("Jump"))
            {
                TutoJumpOK = true;
                TutoJumpImage.color = new Color(0, 255, 0);
            }
        }
    }

    void TutoShoot1()
    {
        if(totorial.gameStats && TutoShootOK == false && Tuto2Bye == true)
        {
            TutoShoot.SetActive(true);
            if (Input.GetButtonDown("Fire1"))
            {
                openDoor = true;
                anim.SetBool("tutook", openDoor);
                bienHecho.SetActive(true);
                Invoke("BienHechoOK", 2.5f);
                TutoShootOK = true;
                TutoShootImage.color = new Color(0, 255, 0);
            }
        }
    }

    void MisionComplete2()
    {
        Mision02.SetActive(false);
        mision2Bye = true;
    }
    void MisionComplete1()
    {
        Mision01.SetActive(false);
        mision1Bye = true;
    }
    void MisionComplete3()
    {
        Mision03.SetActive(false);
    }

    void TutoMoveComplete()
    {
        TutoMove.SetActive(false);
        Tuto1Bye = true;
    }

    void TutoJumpComplete()
    {
        TutoJump.SetActive(false);
        Tuto2Bye = true;
    }

    void TutoShootComplete()
    {
        TutoShoot.SetActive(false);
        Tuto3Bye = true;
    }

    void BienHechoOK()
    {
        bienHecho.SetActive(false);
    }
}
