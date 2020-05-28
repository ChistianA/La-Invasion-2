using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeBlackMenu : MonoBehaviour
{
    public Image fadeBlack;
    public GameObject fadeB;
    float timer;

    private void Start()
    {
        timer = 255f;
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        fadeBlack.color = new Color(0f, 0f, 0f, timer);
        if(timer <= 0)
        {
            fadeB.SetActive(false);
        }
    }
}
