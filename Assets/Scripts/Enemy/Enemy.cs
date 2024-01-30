using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float health;
    public float speed;
    public EnemyData enemyData;
    public Animator animator;
}
