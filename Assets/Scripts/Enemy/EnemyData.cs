using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy", menuName = "Enemies/EnemyData")]
public class EnemyData : ScriptableObject
{

    [Header("Info")]
    public new string name;

    [Header("Stats")]
    public int damage;
    public float speed;

    [Header("UI & Animations")]
    public Sprite sprite;
    public AnimatorController AnimatorController;
}
