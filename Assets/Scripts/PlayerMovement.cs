using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField] float speed = 15.0f;
  [SerializeField] GameObject boundary;

  private Rigidbody2D _rb2d;
  private Vector2 _direction;
  private float _minX;
  private float _maxX;
  private float _minY;
  private float _maxY;

  void Start()
  {
    _rb2d = GetComponent<Rigidbody2D>();
    UpdateBoundaryCoords(boundary);
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
    transform.position = new Vector2(Mathf.Clamp(transform.position.x, _minX, _maxX), Mathf.Clamp(transform.position.y, _minY, _maxY));
  }

  private void UpdateBoundaryCoords(GameObject boundary)
  {
    Bounds playerSize = transform.Find("Body").GetComponent<SpriteRenderer>().bounds;
    float playerWidth = playerSize.size.x;
    float playerHeight = playerSize.size.y;

    Bounds boundarySize = boundary.GetComponent<SpriteRenderer>().bounds;
    _minX = (boundary.transform.position.x - boundarySize.size.x / 2) + playerWidth / 2;
    _maxX = (boundary.transform.position.x + boundarySize.size.x / 2) - playerWidth / 2;
    _minY = (boundary.transform.position.y - boundarySize.size.y / 2) + playerHeight / 2;
    _maxY = (boundary.transform.position.y + boundarySize.size.y / 2) - playerHeight / 2;
  }
}
