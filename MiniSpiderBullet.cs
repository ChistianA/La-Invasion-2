using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniSpiderBullet : MonoBehaviour
{
    float moveSpeed = 7f;
    Rigidbody rb;
    float damage = 10f;
    Nucleo nucleo;
    GameObject target;
    Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("NucleoTarget");
        nucleo = FindObjectOfType<Nucleo>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Nucleo")
        {
            nucleo.life -= damage;
            Destroy(gameObject);
        }
    }
}
