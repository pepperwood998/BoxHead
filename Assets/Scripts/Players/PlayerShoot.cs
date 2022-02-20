using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
  private Weapon _weapon;

  void Start()
  {
    _weapon = GetComponentInChildren<Weapon>();
  }

  void Update()
  {
    if (_weapon != null && Input.GetMouseButtonDown(0))
    {
      Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      _weapon.Shoot(mouseWorldPosition);
    }
  }
}
