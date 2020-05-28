using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectorVictoria : MonoBehaviour
{
    public Animator anim;
    public Animator animB1;
    public Animator animB2;
    public bool win = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            win = true;
            anim.SetBool("Victory", true);
            animB1.SetBool("End", true);
            animB2.SetBool("End", true);
        }
    }
}
