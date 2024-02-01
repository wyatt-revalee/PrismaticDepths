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

    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if(enemy.gameObject.layer != 8)
        {
            return;
        }
        float force = weaponData.knockbackForce * player.playerStats.knockback.Value;
        enemy.gameObject.GetComponent<IDamageable>().Damage(weaponData.currentDamage);
        enemy.gameObject.GetComponent<IKnockbackable>().DoKnockback(new Vector2(force * 100, force * 100));
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

}
