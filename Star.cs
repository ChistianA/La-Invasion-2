using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    GameManager starP;
    Text starText;
    PlayerMove playerM;

    // Start is called before the first frame update
    void Start()
    {
        playerM = FindObjectOfType<PlayerMove>();
        starP = FindObjectOfType<GameManager>();
        starText = GameObject.Find("StarText").GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerM.audioEstrella.Play();
            starP.stars += 1;
            starText.text = starP.stars.ToString() + "/5";
            Destroy(gameObject);
        }
    }
}
