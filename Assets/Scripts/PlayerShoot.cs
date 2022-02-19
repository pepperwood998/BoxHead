using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
  private IWeapon _weapon;

  void Start()
  {
    _weapon = GetComponentInChildren<IWeapon>();
  }

  void Update()
  {
    if (_weapon != null && Input.GetMouseButtonDown(0))
    {
      _weapon.Attack();
    }
  }
}
