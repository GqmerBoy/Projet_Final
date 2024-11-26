using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent; //Pour le navMeshAgent
    [SerializeField] private Transform _tower; //La tour pricipale

    [Header("Attributs")]
    public float range = 15f; //La distance avant que l'enemie peut tirer
    public float fireRate = 1f; //La vitesse à laquelle l'enemie tire
    public float health = 100; //Les PVs de l'enemie


    [Header("Unity setup")]
    
    [SerializeField] private GameObject bulletPrefab; //Le projectile de l'enemie
    [SerializeField] private Transform firePoint; //Le point départ du projectile
    [SerializeField] private Material[] material; //Les matériaux de l'enemie


    private int _element = 0; //L'élément du matériel
    private Renderer _renderer; 
    private float fireCountdown = 0f; //Le countdown pour le fireRate
    private string towerTag = "Tower"; //Le tag de la tour



    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>(); 

        _renderer = GetComponent<Renderer>();
        _renderer.enabled = true;
        _renderer.sharedMaterial = material[_element];
    }



    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(_tower.transform.position);

        _renderer.sharedMaterial = material[_element];
        EnemyHealth(); //Change le matriel de l'enemie pour avertir le joueur que cet enemie est presque mort
        Target(); //Appelle la fonction Shoot() si l'enemy est assez proche de la tour à une fréquence de tir définie.
    }



    private void EnemyHealth()
    {
        if(health <= 25)
        {
            Debug.Log(health);
            _element = 1;
        }

        else
        {
            _element = 0;
        }
    }



    private void Shoot()
    {
        //Debug.Log("Shoot");
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Seek(_tower);
        }
    }



    //Pour voir la distance du range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }



    void Target()
    {
        GameObject tower = GameObject.FindGameObjectWithTag(towerTag);
        
        if (tower.tag == "Tower")
        {
            float distanceToTower = Vector3.Distance(transform.position, _tower.transform.position); //La distance en la tour et l'enemie
            
            if (distanceToTower <= range && fireCountdown <= 0) {
                Shoot(); //Fait spawner un projectile vers la tour
                fireCountdown = 1 / fireRate; //Vitesse de tir
            }
        }

        fireCountdown -= Time.deltaTime; //Pour que le countdown soit à la seconde près
    }
}
