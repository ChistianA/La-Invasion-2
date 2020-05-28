using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public float damage = 50f;
    public float range = 100f;
    public float fireRate = 8f;
    float nextTimeToFire = 0f;

    public Camera fpsCam;
    public ParticleSystem flashGun;
    public GameObject ImpactEffect;
    public AudioSource audioS;
    public Tutorial tuto;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire && tuto.gameStats == true){
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            
        }
    }

    void Shoot(){
        flashGun.Play();
        audioS.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, 9)){
            Target target = hit.transform.GetComponent<Target>();
            Bicho_ADistancia target2 = hit.transform.GetComponent<Bicho_ADistancia>();
            Bicho_Reina target3 = hit.transform.GetComponent<Bicho_Reina>();
            MiniSpider target4 = hit.transform.GetComponent<MiniSpider>();
            if(target != null){
                target.TakeDamge(damage);
            }
            if(target2 != null)
            {
                target2.TakeDamge(damage);
            }
            if (target3 != null)
            {
                target3.TakeDamge(damage);
            }
            if  (target4 != null)
            {
                target4.TakeDamage(damage);
            }
            GameObject impactGO = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO,0.5f);
        }
    }
}
