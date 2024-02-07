using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy, IDamageable, IKnockbackable
{
    
    void Start()
    {
        SetStatsToLevel(5);
    }

    void Update()
    {
    }


    // Gets the direction faced by the enemy (1 == positive x == right)
    public int GetDirection()
    {
        return transform.localScale.x > 0 ? 1 : -1;
    }

    // Called by other objects to damage slime
    public void Damage(int damage)
    {
        Debug.Log(string.Format("Slime took {0} damage!", damage));
        health -= damage;
        if(health <= 0)
        {
            StartCoroutine(DoDeath());
        }
        Debug.Log(this.health);
    }

    // Called when health reaches 0, animates death then destroys enemy
    public IEnumerator DoDeath()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

    public void Knockback(Vector2 force)
    {
        StartCoroutine(DoKnockback(force));
    }

    public IEnumerator DoKnockback(Vector2 force)
    {
        this.GetComponent<Rigidbody2D>().velocity = force;
        yield return new WaitForSeconds(0f);
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        Debug.Log(player.gameObject.layer);
        // If object isn't the player, return
        if (player.gameObject.layer != 12)
        {
            return;
        }
        Debug.Log("Player entered 2d");
        // Damage player
        player.gameObject.GetComponent<IDamageable>().Damage(damage);

        // Add knockback player, based on enemy's knockback power. Make x value equal to player's faced direction.
        player.gameObject.GetComponent<IKnockbackable>().Knockback(new Vector2(knockback * GetDirection(), knockback));
    }

}
