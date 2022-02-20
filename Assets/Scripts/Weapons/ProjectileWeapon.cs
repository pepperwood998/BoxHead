using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
  [SerializeField] GameObject bulletPrefab;

  private GameObject _weaponTip;

  void Start()
  {
    _weaponTip = FindGameObjectInChildrenWithTag(gameObject, "WeaponTip");
  }

  public override void Shoot(Vector3 targetPosition)
  {
    Vector3 bulletDirection = (targetPosition - _weaponTip.transform.position).normalized;
    float bulletAngle = Mathf.Atan2(bulletDirection.x, bulletDirection.y);

    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
    ProjectileMovement bulletMovement = bullet.GetComponent<ProjectileMovement>();
    bulletMovement.MoveAngle = bulletAngle;
  }

  private GameObject FindGameObjectInChildrenWithTag(GameObject parent, string tag)
  {
    Transform transform = parent.transform;

    for (int i = 0; i < transform.childCount; i++)
    {
      if (transform.GetChild(i).CompareTag(tag))
      {
        return transform.GetChild(i).gameObject;
      }
    }

    return null;
  }
}
