using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.InputSystem;
using static EnemyData;

public abstract class Enemy : MonoBehaviour
{

    public int health;
    public int damage;
    public int speed;
    public EnemyData enemyData;
    public Animator animator;

    public void UpdateStats(int level)
    {
        foreach(KeyValuePair<string, int> stat in enemyData.SetStatsToLevel(level))
        {
            switch(stat.Key)
            {
                case "health":
                    health = stat.Value;
                    break;

                case "damage":
                    damage = stat.Value;
                    break;

                case "speed":
                    speed = stat.Value;
                    break;
            }
        }
    }
}
