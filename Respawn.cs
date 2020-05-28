using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    PlayerMove playerMove;
    public bool restartEnemys = false;
    public GameObject puntRespawn;
    public GameObject puntRespawn2;
    ActivarOleadas actOleadas;
    public Vector3 RespawnPos;
    public Transform trans;
    HealthBar healthBar;
    SpawnEnemigos spawnEnemy;
    Nucleo nucleo;
    DetectorA2 level2Start;
    MiniSpider miniS;
    TimerNucleo timer;
    public ParticleSystem smoke1;
    public ParticleSystem smoke2;

    // Start is called before the first frame update
    void Start()
    {
        miniS = FindObjectOfType<MiniSpider>();
        level2Start = FindObjectOfType<DetectorA2>();
        nucleo = FindObjectOfType<Nucleo>();
        RespawnPos = puntRespawn.transform.position;
        playerMove = FindObjectOfType<PlayerMove>();
        healthBar = FindObjectOfType<HealthBar>();
        actOleadas = FindObjectOfType<ActivarOleadas>();
        spawnEnemy = FindObjectOfType<SpawnEnemigos>();
        timer = FindObjectOfType<TimerNucleo>();

    }

    // Update is called once per frame
    void Update()
    {
        if (level2Start.Level2Start)
        {
            RespawnPos = puntRespawn2.transform.position;
        }
        RespawnP();
        
    }

    public void RespawnP()
    {
        if (playerMove.health <= 0 || nucleo.life <= 0f && timer.victory == false)
        {
            nucleo.life = 1000f;
            playerMove.lifes -= 1;
            Debug.Log(playerMove.lifes);
            trans.position = RespawnPos;
            spawnEnemy.startGame = false;
            playerMove.health = playerMove.maxHealth;
            healthBar.SetHealth(playerMove.health);
            actOleadas.Startt = false;
            actOleadas.proyectorL.enabled = true;
            actOleadas.luzRoja.enabled = false;
            timer.alarma.Stop();
            smoke1.Stop();
            smoke2.Stop();

            DestroyEnemys("Enemies");
        }

    }

    public void DestroyEnemys(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject target in gameObjects)
        {
            GameObject.Destroy(target);
        }
    }
}
