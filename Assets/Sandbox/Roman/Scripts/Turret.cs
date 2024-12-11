using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("General")]

    [SerializeField] float range = 15f;

    [Header("Use Bullets (default)")]

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float fireRate = 1;
    private float fireCountdown = 0f;

    [Header("Use Laser")]

    [SerializeField] bool useLaser = false;
    [SerializeField] LineRenderer lineRenderer;

    [Header("Use Missiles")]
    [SerializeField] bool useMissiles = false;
    [SerializeField] GameObject missilePrefab;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";
    [SerializeField] float turnSpeed = 10f;
    [SerializeField] Transform target;
    [SerializeField] Transform partToRotate;
    [SerializeField] Transform firePoint;
     

    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget() 
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;


        foreach (GameObject enemy in enemies)
        { 
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) 
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range) 
        {
            target = nearestEnemy.transform;
        }
        else 
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if(lineRenderer.enabled)
                    lineRenderer.enabled = false;
            }

            return;
        }


        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }else
        {
            if (fireCountdown <= 0F)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    void LockOnTarget() 
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Quaternion rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed);
        partToRotate.rotation = Quaternion.Euler(0f, rotation.eulerAngles.y, 0f);
    }

    void Laser()
    {
        if(!lineRenderer.enabled)
            lineRenderer.enabled = true;

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }

    void Shoot()
    {
        GameObject projectile;
        if (useMissiles)
        {
            projectile = Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
            Missile missile = projectile.GetComponent<Missile>();
            if (missile != null)
            {
                missile.Seek(target);
            }
        }
        else
        {
            projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bulletComponent = projectile.GetComponent<Bullet>();
            if (bulletComponent != null)
            {
                bulletComponent.Seek(target);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
