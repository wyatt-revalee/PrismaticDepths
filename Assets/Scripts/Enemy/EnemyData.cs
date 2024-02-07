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
    public int health;
    public int damage;
    public int speed;
    public int knockback;

    [Header("UI & Animations")]
    public Sprite sprite;
    public AnimatorController AnimatorController;

    public Dictionary<string, int> UpdateStats()
    {
        return new Dictionary<string, int>
        {
            {"health", health},
            {"damage", damage},
            {"speed", speed},
            {"knockback", knockback},
        };
    }
}
