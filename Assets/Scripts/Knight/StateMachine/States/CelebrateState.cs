using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebrateState : State
{
    [SerializeField] private Animator _animator;

    private const string AnimationJump = "Jump";

    private void OnEnable()
    {
        CurrentKnight.TakeArmor();
        _animator.speed = 1;
        _animator.SetBool(AnimationJump, true);
    }

    private void OnDisable()
    {
        _animator.SetBool(AnimationJump, false);
    }
}
