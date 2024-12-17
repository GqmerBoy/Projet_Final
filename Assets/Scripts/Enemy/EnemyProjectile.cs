using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private Transform tower;
    
    [SerializeField] private BulletSO bulletSO;
    [SerializeField] private TowerSO towerSO;
    [SerializeField] private MainTowerHealth mainTowerHealth;

    public void Seek(Transform target){
        tower = target;
    }

    void Start()
    {
        mainTowerHealth = GameObject.FindGameObjectWithTag("Tower").GetComponent<MainTowerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tower == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = tower.position - transform.position; //La direction dans laquelle l'enemie tir
        float distanceThisFrame = bulletSO.vitesseDeplacement * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTower(); //Appel lorsque la distance entre le projectile et la tour est 0
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void HitTower()
    {
        Destroy(gameObject); //Détruit le projectile lorsqu'il touche la tour
        mainTowerHealth.TakeDamage(bulletSO.dommages); //Met des dommages à la tour
        return;
    }
}
