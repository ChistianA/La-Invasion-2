using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Bicho_ADistancia : MonoBehaviour
{
    public float health = 50f;
    Transform player;
    PlayerMove playerS;
    NavMeshAgent nav;
    Animator anim;
    float distancia;
    bool running;
    bool attack = false;
    bool shoot;
    float contador = 0f;
    public GameObject bullet;
    Respawn resetEnemys;
    public int bichoDistancia_killed;
    Text Ndis;
    public GameObject corazon;
    float droprate = 10f;
    SphereCollider colliderS;
    SpawnEnemigos numEnemigos;
    public AudioSource bichoMuriendo;


    private void Start()
    {
        playerS = FindObjectOfType<PlayerMove>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        resetEnemys = FindObjectOfType<Respawn>();
        Ndis = GameObject.Find("Ndistancia").GetComponent<Text>();
        colliderS = GetComponent<SphereCollider>();
        numEnemigos = FindObjectOfType<SpawnEnemigos>();

    }
    private void Update()
    {
        contador += Time.deltaTime;
        nav.SetDestination(player.position);
        distancia = Vector3.Distance(player.position, transform.position);
        if (distancia > 14.5)
        {
            running = true;
            shoot = false;
        }
        if (distancia < 14.5)
        {
            running = false;
            shoot = true;
        }

        if (shoot && contador >= 1f)
        {
            Shoot();
            contador = 0f;
        }
        anim.SetBool("Run Forward", running);
        anim.SetBool("Stab Attack", attack);
        anim.SetBool("Cast Spell", shoot);

        if (resetEnemys.restartEnemys == true)
        {
            anim.Play("Die");
            nav.enabled = false;
            Invoke("Die", 1f);
        }
    }

    public void TakeDamge(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            bichoMuriendo.Play();
            numEnemigos.enemigosMuertosDis += 1;
            Ndis.text = numEnemigos.enemigosMuertosDis.ToString();
            colliderS.enabled = false;
            if (Random.Range(0, 100) <= droprate)
            {
                Instantiate(corazon, transform.position, Quaternion.identity);
            }
            anim.Play("Die");
            nav.enabled = false;
            Invoke("Die", 1f);
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
