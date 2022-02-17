using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
  [SerializeField] float minZoom = 7.0f;
  [SerializeField] float maxZoom = 11.0f;
  [SerializeField] float zoomLimiter = 15.0f;

  private Camera _camera;
  private GameObject[] _followings;
  private Bounds _followingBounds;

  void Start()
  {
    _camera = GetComponent<Camera>();
    _followings = GameObject.FindGameObjectsWithTag("Player");
  }

  void Update()
  {
  }

  void LateUpdate()
  {
    if (_followings.Length == 0)
    {
      return;
    }

    _followingBounds = GetNewBounds();

    Vector3 centerPoint = GetCenterPoint();
    transform.position = new Vector3(centerPoint.x, centerPoint.y, transform.position.z);

    float newZoom = Mathf.Lerp(minZoom, maxZoom, GetGreatestDistance() / zoomLimiter);
    _camera.orthographicSize = newZoom;
  }

  private Bounds GetNewBounds()
  {
    Bounds followingBounds = new Bounds(_followings[0].transform.position, Vector3.zero);
    for (int i = 0; i < _followings.Length; i++)
    {
      followingBounds.Encapsulate(_followings[i].transform.position);
    }
    return followingBounds;
  }

  private Vector3 GetCenterPoint()
  {
    if (_followings.Length == 1)
    {
      return _followings[0].transform.position;
    }
    return _followingBounds.center;
  }

  private float GetGreatestDistance()
  {
    return Mathf.Max(_followingBounds.size.x, _followingBounds.size.y);
  }
}
