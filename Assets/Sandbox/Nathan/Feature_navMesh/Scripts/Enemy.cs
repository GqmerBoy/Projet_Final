using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent; //Pour le navMeshAgent
    [SerializeField] private Transform tower; //La tour pricipale

    [SerializeField] EnemySO enemySO;


    [Header("Unity setup")]
    
    [SerializeField] private GameObject bulletPrefab; //Le projectile de l'enemie
    [SerializeField] private Transform firePoint; //Le point départ du projectile


    private int _element = 0; //L'élément du matériel
    private float fireCountdown = 0f; //Le countdown pour le fireRate
    private string towerTag = "Tower"; //Le tag de la tour



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); 
    }



    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(tower.transform.position); //Destination du NavMesh

        Target(); //Appelle la fonction Shoot() si l'enemy est assez proche de la tour à une fréquence de tir définie.
    }

    private void Shoot()
    {
        //Debug.Log("Shoot");
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Seek(tower);
        }
    }



    //Pour voir la distance du range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemySO.rangeTir);
    }



    void Target()
    {
        GameObject tower = GameObject.FindGameObjectWithTag(towerTag);
        
        if (tower.tag == "Tower")
        {
            float distanceToTower = Vector3.Distance(transform.position, tower.transform.position); //La distance en la tour et l'enemie
            
            if (distanceToTower <= enemySO.rangeTir && fireCountdown <= 0) {
                agent.speed = 0; //Fait arrêter l'enemie
                Shoot(); //Fait spawner un projectile vers la tour
                fireCountdown = 1 / enemySO.vitesseTir; //Vitesse de tir
            }

        }

        fireCountdown -= Time.deltaTime; //Pour que le countdown soit à la seconde près
    }
}
