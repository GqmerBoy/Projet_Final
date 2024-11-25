using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _tower;

    [Header("Attributs")]
    public float range = 15f;
    public float fireRate = 1f;
    public float health = 100;


    [Header("Unity setup")]
    
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Material[] material;


    private int _element = 0;
    private Renderer _renderer;
    private float fireCountdown = 0f;
    private string towerTag = "Tower";


    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _tower = FindAnyObjectByType<ClickToMove>().transform;

        _renderer = GetComponent<Renderer>();
        _renderer.enabled = true;
        _renderer.sharedMaterial = material[_element];
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(_tower.position);

        _renderer.sharedMaterial = material[_element];
        EnemyHealth();

        //Appelle la fonction Shoot() si l'enemy est assez proche de la tour à une fréquence de tir définie.
        if (fireCountdown <= 0f && _tower.CompareTag(towerTag))
        {
            float distanceToTower = Vector3.Distance(transform.position, _tower.transform.position);
            
            if (distanceToTower <= range) {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
        }

        fireCountdown -= Time.deltaTime;
    }

    //Change le matriel de l'enemie pour avertir le joueur que cet enemie est presque mort
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

    //Fait spawner un projectile vers la tour
    private void Shoot()
    {
        Debug.Log("Shoot");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    //Pour voir la distance du range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
