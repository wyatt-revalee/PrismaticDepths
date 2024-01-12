using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public PlayerStats playerStats;
    public HealthBar healthBar;
    public ManaBar manaBar;
    public Weapon currentWeapon;
    public float currentHealth;
    public float currentMana;
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        currentHealth = playerStats.maxHealth.Value;
        healthBar.SetMaxHealth(currentHealth);
        currentMana = playerStats.maxMana.Value;
        manaBar.SetMaxMana(currentMana);
    }

    void FixedUpdate()
    {
        healthBar.SetHealth(currentHealth);
        RegenMana();
    }

    public void UseMana(float manaCost)
    {
        currentMana -= manaCost;
        manaBar.SetMana(currentMana);
    }

    void RegenMana()
    {
        if(currentMana < playerStats.maxMana.Value)
        {
            currentMana += playerStats.manaRegen.Value;
        }

        if(currentMana > playerStats.maxMana.Value)
        {
            currentMana = playerStats.maxMana.Value;
        }
        manaBar.SetMana(currentMana);
    }

}
