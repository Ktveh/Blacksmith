using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateDuration;
    [SerializeField] private Animator _animator;

    private Transform _currentTarget;

    private const string AnimationWalk = "Walk";

    private void OnEnable()
    {
        _animator.SetBool(AnimationWalk, true);
        _animator.speed = 1;
        _currentTarget = CurrentKnight.MiddlePosition;
        transform.DOLookAt(_currentTarget.position, _rotateDuration);
    }

    private void OnDisable()
    {
        _animator.SetBool(AnimationWalk, false);
    }

    private void Update()
    {
        Move();
        CheckPosition();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _speed * Time.deltaTime);
    }

    private void CheckPosition()
    {
        if (transform.position == CurrentKnight.Target.position)
        {
            return;
        }
        if (transform.position == _currentTarget.position)
        {
            _currentTarget = CurrentKnight.Target;
        }
    }
}
