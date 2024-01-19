using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    public WeaponData weaponData;
    public Player player;
    public Animator playerAnimator;

    public abstract void PrimaryAttack();
    public abstract void SecondaryAttack();
    public abstract void UtilityAttack();
    public abstract void SpecialAttack();

    public void PrintName()
    {
        Debug.Log(weaponData.name);
    }

    public void GetPlayer()
    {
        player = this.transform.parent.transform.GetComponent<Player>();
    }

    public void OverrideAnimator()
    {
        playerAnimator = this.transform.parent.transform.GetComponent<Animator>();
        playerAnimator.runtimeAnimatorController = weaponData.animatorOverrideController;
    }

}
