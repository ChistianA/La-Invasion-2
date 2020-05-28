using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MiniSpider : MonoBehaviour
{
    NavMeshAgent nav;
    Transform nucleoT;
    Nucleo nucleo;
    float distancia;
    float contador;
    bool attack;
    bool running;
    Animator anim;
    float damage = 10f;
    public float life = 10f;
    SphereCollider colliderS;
    Rigidbody rb;
    public AudioSource MSDie;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nucleo = GameObject.FindGameObjectWithTag("Nucleo").GetComponent<Nucleo>();
        nucleoT = GameObject.FindGameObjectWithTag("Nucleo").transform;
        anim = GetComponent<Animator>();
        colliderS = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        contador += Time.deltaTime;
        distancia = Vector3.Distance(nucleoT.position, transform.position);
        nav.SetDestination(nucleoT.position);
        if(distancia <= 7.5f)
        {
            anim.SetBool("Attack",true);
            attack = true;
        }
        if(attack && contador >= 2f)
        {
            Shoot();
            contador = 0f;
        }
    }

    private void Attack(float damage)
    {
        nucleo.life -= damage;
    }

    public void TakeDamage(float amount)
    {
        life -= amount;
        if(life <= 0)
        {
            MSDie.Play();
            rb.isKinematic = true;
            colliderS.enabled = false;
            anim.Play("die");
            nav.enabled = false;
            Invoke("Die", 1f);
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
