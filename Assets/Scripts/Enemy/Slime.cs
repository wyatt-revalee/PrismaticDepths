using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy, IDamageable, IKnockbackable
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public int Health { get; set; }

    public void Damage(int damage)
    {
        Debug.Log(string.Format("Slime took {0} damage!", damage));
    }

    public IEnumerator DoKnockback(Vector2 force)
    {
        this.GetComponent<Rigidbody2D>().AddForce(force);
        yield return new WaitForSeconds(0f);
    }
}
