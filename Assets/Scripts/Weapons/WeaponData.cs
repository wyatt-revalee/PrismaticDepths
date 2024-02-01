using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Weapon", menuName ="Weapons/Weapon")]
public class WeaponData : ScriptableObject
{

    [Header ("Info")]
    public new string name;
    public string type;

    [Header("Stats")]
    public int damage;
    public int currentDamage;
    public int speed;
    public int manaCost;
    public int knockbackForce;

    [Header("UI & Animations")]
    public Sprite sprite;
    public AnimatorOverrideController animatorOverrideController;
}
