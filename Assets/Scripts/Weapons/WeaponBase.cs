using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
  public virtual void Melee() { }

  public virtual void Shoot(Vector3 targetPosition) { }
}
