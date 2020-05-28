using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject Tutorial1;
    public GameObject Tutorial2;
    public GameObject Tutorial3;
    public bool gameStats;

    public void PasaTuto1()
    {
        Tutorial1.SetActive(false);
        Tutorial2.SetActive(true);
    }

    public void PasaTuto2()
    {
        Tutorial2.SetActive(false);
        Tutorial3.SetActive(true);
    }

    public void PasaTuto3()
    {
        Tutorial3.SetActive(false);
        gameStats = true;
        LockCursor();
    }

    private void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
