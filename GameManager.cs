using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerMove playerM;
    public GameObject player;
    public int stars;

    // Update is called once per frame
    void Update()
    {

        if(playerM.lifes < 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Derrota");
        }
    }

}
