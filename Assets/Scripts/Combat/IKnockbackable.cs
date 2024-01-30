using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKnockbackable
{
    IEnumerator DoKnockback(float force, Vector2 direction);
}
