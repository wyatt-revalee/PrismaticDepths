using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public float damage;

    public string name;
    
    // Speed of attack
    public float speed;

    // affects movement speed of player
    public float weight;
    
    // Staff, axe, sword, etc.
    public float type;

    // 4 different attacks - each a separate class? Or perhaps attack -> sub-class?

    // How do we implement sprites and animations for weapons?
}
