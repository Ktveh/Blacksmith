using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : State
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _minDuration;
    [SerializeField] private float _maxDuration;

    private const string AnimationJump = "Jump";

    private void OnEnable()
    {
        _animator.speed = Random.Range(_minDuration, _maxDuration);
        _animator.SetBool(AnimationJump, true);
    }
}
