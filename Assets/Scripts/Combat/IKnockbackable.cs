using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKnockbackable
{
    IEnumerator DoKnockback(Vector2 force);
}
