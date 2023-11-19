using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerStats : MonoBehaviour
{
    public CharacterStat groundSpeed = new CharacterStat(15f);
    public CharacterStat airSpeed = new CharacterStat(10f);
    public CharacterStat jumpHeight = new CharacterStat(300f);

}
