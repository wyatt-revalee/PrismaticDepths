using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Axe : Weapon
{

    public void Awake()
    {
        GetPlayer();
        SetWeapon();
        OverrideAnimator();
    }

    public override void PrimaryAttack()
    {
        Debug.Log("Axe primary attack!");
        Debug.Log(weaponData.damage);
        player.UseMana(weaponData.manaCost);
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

    void OnCollisionEnter2D()
    {
        Debug.Log("Entered Axe 2D");
    }
}
