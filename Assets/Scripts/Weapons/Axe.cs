using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon
{

    public override void PrimaryAttack()
    {
        Debug.Log("Axe primary attack!");
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
