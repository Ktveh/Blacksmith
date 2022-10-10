using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Knight _knight;
    [SerializeField] private KnightMover _mover;

    private const string AnimationWalk = "Walk";
    private const string AnimationJump = "Jump";
    private const string AnimationBattle = "Battle";

    private void OnEnable()
    {
        _mover.Walked += Walk;
        _mover.Stopped += Stop;
        _knight.Jumped += Jump;
        _knight.Attacked += CahngeBattle;
    }

    private void OnDisable()
    {
        _mover.Walked -= Walk;
        _mover.Stopped -= Stop;
        _knight.Jumped -= Jump;
        _knight.Attacked -= CahngeBattle;
    }

    private void Walk()
    {
        _animator.speed = 1;
        _animator.SetBool(AnimationWalk, true);
    }

    private void Stop()
    {
        _animator.speed = 1;
        _animator.SetBool(AnimationWalk, false);
    }

    private void Jump()
    {
        _animator.speed = 1;
        _animator.SetBool(AnimationJump, false);
    }

    private void CahngeBattle(bool started)
    {
        _animator.SetBool(AnimationBattle, started);
    }
}
