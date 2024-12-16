using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private Transform target;

    [SerializeField] float speed = 30f;
    [SerializeField] float turnSpeed = 3f;
    [SerializeField] GameObject explosionEffect;
    [SerializeField] GameObject smokeEffect;
    private GameObject currentSmoke;
    public void Seek(Transform _target)
    {
        target = _target;
        // Instantiate smoke when missile is launched
        if (smokeEffect != null)
        {
            currentSmoke = Instantiate(smokeEffect, transform.position, transform.rotation);
            currentSmoke.transform.SetParent(transform); // Make smoke follow missile
        }
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

        if (currentSmoke != null)
        {
            currentSmoke.transform.SetParent(null); // Detach smoke before destroying missile
            Destroy(currentSmoke, 1f); // Destroy smoke after 2 seconds
        }

        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        HitTarget();
    }
}
