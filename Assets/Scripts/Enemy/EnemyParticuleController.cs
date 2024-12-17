using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticuleController : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private AudioSource enemyEnter;
    private bool alreadyPlayed;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        enemyEnter = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall") && !alreadyPlayed)
        {
            particleSystem.Play();
            enemyEnter.Play();
            alreadyPlayed = true;
        }
    }
}
