using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticuleController : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            _particleSystem.Play();
        }
    }
}
