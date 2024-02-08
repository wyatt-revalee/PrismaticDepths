using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IKnockbackable
{

    public PlayerStats playerStats;
    public HealthBar healthBar;
    public ManaBar manaBar;
    public float currentHealth;
    public float currentMana;
    public Weapon primaryWeapon;
    public Collider2D combatCollider;
    public bool unDamageable;
    public bool isDead;
    //Initializing of values
    void Start()
    {
        unDamageable = false;
        isDead = false;
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

    // Called by attacks to reduce player's mana based on cost
    public void UseMana(float manaCost)
    {
        currentMana -= manaCost;
        manaBar.SetMana(currentMana);
    }

    // Regenerates mana based on player's regen rate
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

    // Called by enemies to cause the player to take damage
    public void Damage(int damage)
    {
        if (unDamageable) return;
        if (isDead) return;
        Debug.Log(string.Format("Player took {0} damage", damage));
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            StartCoroutine(PlayerDeath());
        }
    }

    // Called by enemies to cause the player to take knockback force
    public void Knockback(Vector2 force)
    {
        if (unDamageable) return;
        if (isDead) return;
        StartCoroutine(DoKnockback(force));
    }

    // Actual application of knockback force. Coroutine as to not pause anything
    public IEnumerator DoKnockback(Vector2 force)
    {
        unDamageable = true;
        Debug.Log(string.Format("Player took {0} knockback", force.x));
        combatCollider.enabled = false;
        GetComponent<Rigidbody2D>().velocity = force;
        yield return new WaitForSeconds(2f);
        combatCollider.enabled = true;
        unDamageable = false;
    }

    public IEnumerator PlayerDeath()
    {
        yield return new WaitForSeconds(0.5f);
        isDead = true;
        GetComponent<PlayerMovement>().DisableMovement();
        yield return new WaitForSeconds(3f);
    }

}
