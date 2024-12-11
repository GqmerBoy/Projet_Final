using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private Transform target;
    [SerializeField] float speed = 30f;
    [SerializeField] float turnSpeed = 3f;
    [SerializeField] GameObject explosionEffect;
    
    [Header("Smoke Effects")]
    [SerializeField] private TrailRenderer coreTrail;
    [SerializeField] private TrailRenderer mediumTrail;
    [SerializeField] private TrailRenderer outerTrail;

    public void Seek(Transform _target)
    {
        target = _target;
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
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
        
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(Vector3.forward * distanceThisFrame, Space.Self);
    }

    void HitTarget()
    {
        if (explosionEffect != null)
        {
            GameObject effectIns = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        HitTarget();
    }
}
