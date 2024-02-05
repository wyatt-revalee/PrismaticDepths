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

}
