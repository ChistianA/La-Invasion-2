using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DetectorFinal : MonoBehaviour
{
    public Image pantallaNegra;
    float timer = 0f;
    float timerend = 3f;
    // Update is called once per frame
    void Update()
    {
        if (pantallaNegra.enabled)
        {
            timerend -= Time.deltaTime;
            timer += Time.deltaTime;
            pantallaNegra.color = new Color(0f, 0f, 0f, timer);
            if(timer >= 255f)
            {
                timer = 255f;
            }
            if(timerend <= 0f)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("Victory");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pantallaNegra.enabled = true;
        }
        
    }
}
