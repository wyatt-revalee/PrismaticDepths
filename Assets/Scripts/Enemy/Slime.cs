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

    }

    public IEnumerator DoKnockback(float force, Vector2 direction)
    {
        yield return new WaitForSeconds(1f);
    }
}
