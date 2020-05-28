using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Target : MonoBehaviour
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
    HealthBar healthBar;
    Respawn resetEnemys;
    public int bichoMele_killed = 0;
    Text Nmele;
    public GameObject corazon;
    float droprate = 10f;
    SpawnEnemigos numEnemigos;
    SphereCollider colliderS;
    public AudioSource bichoMuriendo;
    AguaMagica aguaM;

    private void Start() {
        numEnemigos = FindObjectOfType<SpawnEnemigos>();
        playerS = FindObjectOfType<PlayerMove>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        colliderS = GetComponent<SphereCollider>();
        nav = GetComponent<NavMeshAgent>();
        healthBar = FindObjectOfType<HealthBar>();
        resetEnemys = FindObjectOfType<Respawn>();
        Nmele = GameObject.Find("Nmele").GetComponent<Text>();
        aguaM = FindObjectOfType<AguaMagica>();
    }
    private void Update() {
        contador += Time.deltaTime;
        nav.SetDestination(player.position);
        distancia = Vector3.Distance(player.position, transform.position);
        if(distancia > 2.5){
            running = true;
            attack = false;
        }
        if(distancia < 2.5){
            running = false;
            attack = true;
        }
        if(attack && contador >= 1f){
            Attack(damage);
            contador = 0f;
        }
        anim.SetBool("Run Forward",running);
        anim.SetBool("Stab Attack",attack);

        if (resetEnemys.restartEnemys == true)
        {
            anim.Play("Die");
            nav.enabled = false;
            Invoke("Die", 1f);
        }
    }

    public void TakeDamge(float amount){
        health -= amount;
        if(health <= 0){
            bichoMuriendo.Play();
            numEnemigos.enemigosMuertosMele += 1;
            Nmele.text = numEnemigos.enemigosMuertosMele.ToString();
            colliderS.enabled = false;
            if(Random.Range(0,100) <= droprate)
            {
                Instantiate(corazon, transform.position, Quaternion.identity);
            }
            anim.Play("Die");
            nav.enabled = false;
            Invoke("Die", 1f);
        }
    }

    private void Attack(float damage){
        if (aguaM.invulnerable == false)
        {
            playerS.audioOff.Play();
            playerS.health -= damage;
            healthBar.SetHealth(playerS.health);
        }

    }

    void Die(){
        
        Destroy(gameObject);
    }
}
