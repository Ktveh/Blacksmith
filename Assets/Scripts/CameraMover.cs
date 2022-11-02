using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotate;

    private bool _isMove;

    private void Start()
    {
        _isMove = false;
    }

    private void Update()
    {
        if (_isMove)
        {
            Move();
        }
    }

    public void StartMove()
    {
        _isMove = true;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime * _speedMove);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _target.rotation, Time.deltaTime * _speedRotate);
        if (transform.position == _target.position && transform.rotation == _target.rotation)
        {
            gameObject.SetActive(false);
        }
    }
}
