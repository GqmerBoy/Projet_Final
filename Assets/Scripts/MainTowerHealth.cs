using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTowerHealth : MonoBehaviour
{
    [SerializeField] private TowerSO towerSO;
    [SerializeField] private HealthBar healthBar;
    private float currentHealth;

    void Start()
    {
        currentHealth = towerSO.health;
        healthBar.SetMaxHealth(towerSO.health);
    }

    private void Death()
    {
        if (towerSO.health <= 0)
        {
            Destroy(this.gameObject);
            //UIManager.GameOver();
            return;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
