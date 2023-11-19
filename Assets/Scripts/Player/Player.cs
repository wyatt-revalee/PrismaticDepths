using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public PlayerStats playerStats;
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    void Update()
    {
    }

}
