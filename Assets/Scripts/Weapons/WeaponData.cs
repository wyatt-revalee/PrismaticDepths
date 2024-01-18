using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Weapon", menuName ="Weapons/Weapon")]
public class WeaponData : ScriptableObject
{

    [Header ("Info")]
    public new string name;
    public Sprite sprite;

    [Header("Stats")]
    public float damage;
    public float speed;
    public float manaCost;
}
