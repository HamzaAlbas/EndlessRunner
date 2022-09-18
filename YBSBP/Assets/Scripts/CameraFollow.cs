using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    #region VARIABLES

    private Transform _player;
    private Vector3 _camOffset;
    private float smoothTime = 0.3f;
    private Vector3 _velocity = Vector3.zero;
    private Vector3 _targetPos, _playerPos;
    #endregion

    private void Start()
    {
        GetReferences();
    }


    private void LateUpdate()
    {
        var playerPosition = _player.position;
        _targetPos = playerPosition + _camOffset;
        var camPos = transform.position;
        camPos = Vector3.SmoothDamp(camPos, playerPosition, ref _velocity, smoothTime);
        camPos = playerPosition + _camOffset;
        transform.position = camPos;
    }

    private void GetReferences()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _camOffset = transform.position - _player.position;
    }
}