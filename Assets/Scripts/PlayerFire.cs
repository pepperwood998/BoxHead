using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
  [SerializeField] GameObject bulletPrefab;

  void Start()
  {

  }

  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));

      Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      Vector3 bulletDirection = (mouseWorldPosition - transform.position).normalized;
      float bulletAngle = Mathf.Atan2(bulletDirection.x, bulletDirection.y);
      Debug.Log(bulletAngle);
      ProjectileMovement bulletMovement = bullet.GetComponent<ProjectileMovement>();
      bulletMovement.MoveAngle = bulletAngle;
    }
  }
}
