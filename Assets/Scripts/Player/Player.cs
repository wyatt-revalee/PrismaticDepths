using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public PlayerStats playerStats;
    public HealthBar healthBar;
    float currentHealth;
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        currentHealth = playerStats.maxHealth.Value;
        healthBar.SetMaxHealth(currentHealth);
    }

    void FixedUpdate()
    {
        healthBar.SetHealth(currentHealth);
    }

}
