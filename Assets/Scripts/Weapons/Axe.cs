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
    }

    private void OnCollisionEnter2D()
    {
        Debug.Log("Collision!");
    }

    public override void SecondaryAttack()
    {
        Debug.Log("Axe secondary attack!");
    }

    public override void UtilityAttack()
    {
        Debug.Log("Axe utility attack!");
    }

    public override void SpecialAttack()
    {
        Debug.Log("Axe special attack!");
    }

}
