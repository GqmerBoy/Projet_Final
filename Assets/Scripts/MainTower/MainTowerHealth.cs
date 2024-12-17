using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTowerHealth : MonoBehaviour
{
    [SerializeField] private TowerSO towerSO;
    [SerializeField] private HealthBar healthBar;
    private float currentHealth;

    [SerializeField] private AudioClip[] audioClips;
    private AudioSource audioSource;
    private bool isHalfHealth = false;
    private bool isLowHealth = false;
    private bool isDead = false;

    private ParticleSystem particleExplode;

    [SerializeField] private GameOver gameOverUI;


    void Start()
    {
        currentHealth = towerSO.health;
        healthBar.SetMaxHealth(towerSO.health);
        audioSource = GetComponent<AudioSource>();
        particleExplode = GetComponent<ParticleSystem>();
    }

    public void TakeDamage(float damage)
    {
        
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        audioSource.PlayOneShot(audioClips[0]);

        if (currentHealth <= towerSO.health * 0.5f && !isHalfHealth)
        {
            audioSource.PlayOneShot(audioClips[1]);
            isHalfHealth = true;
        }

        if (currentHealth <= towerSO.health * 0.1f && !isLowHealth)
        {
            audioSource.PlayOneShot(audioClips[2]);
            isLowHealth = true;
        }

        if (currentHealth <= 0 && !isDead)
        {
            audioSource.PlayOneShot(audioClips[3]);
            particleExplode.Play();
            gameOverUI.EndGame();
            isDead = true;
            Destroy(gameObject, 1);
            
            return;
        }
    }
}
