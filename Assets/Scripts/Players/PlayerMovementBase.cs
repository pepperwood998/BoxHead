using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBase : MonoBehaviour
{
  [SerializeField] float speed = 15.0f;
  [SerializeField] GameObject boundary;

  protected Rigidbody2D _rb2d;
  protected Vector2 _direction;
  protected float _minX;
  protected float _maxX;
  protected float _minY;
  protected float _maxY;

  void Start()
  {
    _rb2d = GetComponent<Rigidbody2D>();
    UpdateBoundaryCoords(boundary);
  }

  protected void Move()
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
