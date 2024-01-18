using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    public WeaponData weaponData;
    public Player player;
    public abstract void PrimaryAttack();
    public abstract void SecondaryAttack();
    public abstract void UtilityAttack();
    public abstract void SpecialAttack();

    public void PrintName()
    {
        Debug.Log(weaponData.name);
    }
}
