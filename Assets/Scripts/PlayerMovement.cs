using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField] float speed = 15.0f;

  private Rigidbody2D _rb2d;
  private Vector2 _direction;

  void Start()
  {
    _rb2d = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    ////Using Euler angle
    //Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //Vector3 mouseDelta = mouseWorldPosition - transform.position;
    //float angle = Mathf.Atan2(mouseDelta.x, mouseDelta.y) * Mathf.Rad2Deg;
    //transform.rotation = Quaternion.Euler(0, 0, -angle);

    Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector2 mouseDirection = (mouseWorldPosition - (Vector2)transform.position).normalized;
    transform.up = mouseDirection;
    _direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
  }

  void FixedUpdate()
  {
    _rb2d.velocity = speed * _direction;
    //_rb2d.MovePosition((Vector2)transform.position + (speed * Time.deltaTime * _direction));
  }
}
