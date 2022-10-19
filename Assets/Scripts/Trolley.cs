using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trolley : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _finishPosition;
    [SerializeField] private float _speed;

    private Transform _target;

    private void Start()
    {
        _target = _startPosition;
    }

    private void Update()
    {
        Move();
        if (IsReachedPosition(_startPosition))
        {
            _target = _finishPosition;
        }
        if (IsReachedPosition(_finishPosition))
        {
            _target = _startPosition;
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    private bool IsReachedPosition(Transform neededPosition)
    {
        return transform.position == neededPosition.position;
    }
}
