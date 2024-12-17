using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private Transform target;
    [SerializeField] private Enemy enemy;
    [SerializeField] private BulletSO bulletSO;
    [SerializeField] GameObject explosionEffect;
    public void Seek(Transform _target)
    {
        target = _target;
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        if (enemy == null){
            Debug.Log(enemy + "is not defined");
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, bulletSO.vitesseDeplacement * Time.deltaTime);
        
        float distanceThisFrame = bulletSO.vitesseDeplacement * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(Vector3.forward * distanceThisFrame, Space.Self);
    }

    void HitTarget()
    {
        Debug.Log("HIT");
        GameObject effectIns = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        enemy.TakeDamage(bulletSO.dommages);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy")){
            HitTarget();
        }
        
    }
}
