using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Bicho_Reina : MonoBehaviour
{
    public float health = 50f;
    float damage = 10f;
    Transform player;
    PlayerMove playerS;
    NavMeshAgent nav;
    Animator anim;
    float distancia;
    bool running;
    bool attack;
    float contador = 0f;
    float contadorHijos = 0f;
    HealthBar healthBar;
    public GameObject hijo;
    Respawn resetEnemys;
    public int bichoReina_killed;
    Text Nreina;
    public GameObject estrella;
    SphereCollider colliderS;
    SpawnEnemigos numEnemigos;
    public AudioSource bichoMuriendo;
    XPBar expBar;
    AguaMagica aguaM;


    private void Start()
    {
        numEnemigos = FindObjectOfType<SpawnEnemigos>();
        colliderS = GetComponent<SphereCollider>();
        healthBar = FindObjectOfType<HealthBar>();
        expBar = FindObjectOfType<XPBar>();
        playerS = FindObjectOfType<PlayerMove>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        resetEnemys = FindObjectOfType<Respawn>();
        Nreina = GameObject.Find("Nreina").GetComponent<Text>();
        aguaM = FindObjectOfType<AguaMagica>();
        
    }
    private void Update()
    {
        contador += Time.deltaTime;
        contadorHijos += Time.deltaTime;
        nav.SetDestination(player.position);
        distancia = Vector3.Distance(player.position, transform.position);
        if (distancia > 3.5)
        {
            running = true;
            attack = false;
        }
        if (distancia < 3.5)
        {
            running = false;
            attack = true;
        }
        if (attack && contador >= 1f)
        {
            Attack(damage);
            contador = 0f;
        }
        if(contadorHijos >= 3f)
        {
            Reproduccion();
            contadorHijos = 0f;
        }
        anim.SetBool("Run Forward", running);
        anim.SetBool("Stab Attack", attack);

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
            numEnemigos.enemigosMuertosReina += 1;
            playerS.health = 100f;
            healthBar.SetHealth(playerS.health);
            Nreina.text = numEnemigos.enemigosMuertosReina.ToString();
            colliderS.enabled = false;
            Instantiate(estrella, transform.position, Quaternion.identity);
            anim.Play("Die");
            nav.enabled = false;
            Invoke("Die", 1f);
        }

    }

    private void Attack(float damage)
    {
        if (aguaM.invulnerable == false)
        {
            playerS.audioOff.Play();
            playerS.health -= damage;
            healthBar.SetHealth(playerS.health);
        }
        
    }

    private void Reproduccion()
    {
        Instantiate(hijo, transform.position, Quaternion.identity);
    }

    void Die()
    {

        Destroy(gameObject);
    }
}
