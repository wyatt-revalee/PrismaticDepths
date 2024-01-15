using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    public abstract void PrimaryAttack();
    public abstract void SecondaryAttack();
    public abstract void UtilityAttack();
    public abstract void SpecialAttack();
}
