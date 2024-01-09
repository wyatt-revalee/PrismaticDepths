using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.TextCore.Text;



// Potentiall some more movement stats later (ex: max speeds, slow down speeds, etc.)
public class PlayerStats : MonoBehaviour
{

    // Movement
    public CharacterStat groundSpeed = new CharacterStat(15f);
    public CharacterStat airMoveSpeed = new CharacterStat(10f);
    public CharacterStat maxFallSpeed = new CharacterStat(10f);
    public CharacterStat jumpHeight = new CharacterStat(300f);

    // Health
    public CharacterStat maxHealth = new CharacterStat(10f);

    // Mana
    public CharacterStat maxMana = new CharacterStat(100f);
    public CharacterStat manaRegen = new CharacterStat(0.2f);

}
