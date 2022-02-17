using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
  [SerializeField] float speed = 15.0f;

  private float _moveAngle;
  private float _xSpeed;
  private float _ySpeed;

  public float MoveAngle
  {
    get { return _moveAngle; }
    set
    {
      _moveAngle = value;
      _xSpeed = Mathf.Sin(value) * speed;
      _ySpeed = Mathf.Cos(value) * speed;
    }
  }

  void Start()
  {

  }

  void Update()
  {
    transform.position += new Vector3(_xSpeed, _ySpeed, 0) * Time.deltaTime;
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("Structure"))
    {
      Destroy(this.gameObject);
    }
  }
}
