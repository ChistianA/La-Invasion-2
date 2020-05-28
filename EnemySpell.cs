using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpell : MonoBehaviour
{

    float moveSpeed = 7f;
    Rigidbody rb;
    float damage = 10f;
    HealthBar healthBar;
    PlayerMove target;
    Vector3 moveDirection;
    AguaMagica aguaM;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = FindObjectOfType<PlayerMove>();
        healthBar = FindObjectOfType<HealthBar>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
        Destroy(gameObject, 3f);
        aguaM = FindObjectOfType<AguaMagica>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (aguaM.invulnerable == false)
            {
                target.audioOff.Play();
                target.health -= damage;
                healthBar.SetHealth(target.health);
                Destroy(gameObject);
            }

        }
    }
}
