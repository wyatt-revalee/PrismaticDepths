using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Axe : Weapon
{
    //test edit
    public void Awake()
    {
        GetPlayer();
        SetWeapon();
        OverrideAnimator();
        GetCollider();
    }

    public override void PrimaryAttack()
    {
        player.UseMana(weaponData.manaCost);
        weaponData.currentDamage = weaponData.damage * 3;
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if(enemy.gameObject.layer != 8)
        {
            return;
        }

        PlayerMovement pm = player.GetComponent<PlayerMovement>();

        float force = weaponData.knockbackForce * player.playerStats.knockback.Value;
        enemy.gameObject.GetComponent<IDamageable>().Damage(weaponData.currentDamage);
        // Add knockback force to the enemy, based on the weapon's knockback, multiplied by the player's modifier. Make x value equal to player's faced direction.
        enemy.gameObject.GetComponent<IKnockbackable>().Knockback(new Vector2(force * pm.GetDirection(), force));

        // Add camera shake
        ShakeCamera();

        // Add Recoil
        AddRecoil(pm);
    }

    public override void SecondaryAttack()
    {
        Debug.Log("Axe secondary attack!");
        weaponData.currentDamage = weaponData.damage * 2;

    }

    public override void UtilityAttack()
    {
        Debug.Log("Axe utility attack!");
        weaponData.currentDamage = weaponData.damage * 1;
    }

    public override void SpecialAttack()
    {
        Debug.Log("Axe special attack!");
        weaponData.currentDamage = weaponData.damage * 5;
    }

    public void AddRecoil(PlayerMovement pm)
    {
        // If player hits an enemy/object below them, add bounce
        if(pm.aimDirection.y < 0)
        {
            pm.physicsBody.velocity = new Vector2(pm.physicsBody.velocity.x, 6);
            Debug.Log("Bounce!");
        }
    }

}
