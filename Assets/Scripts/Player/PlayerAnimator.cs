using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMover _mover;

    private const string AnimationWalk = "Walk";
    private const string AnimationTake = "Take";

    private void OnEnable()
    {
        _player.Taked += Take;
        _player.Gived += Give;
        _mover.Walked += Walk;
        _mover.Stopped += Stop;
    }

    private void OnDisable()
    {
        _player.Taked -= Take;
        _player.Gived -= Give;
        _mover.Walked -= Walk;
        _mover.Stopped -= Stop;
    }

    private void Walk()
    {
        _animator.SetBool(AnimationWalk, true);
    }

    private void Stop()
    {
        _animator.SetBool(AnimationWalk, false);
    }

    private void Give()
    {
        _animator.SetBool(AnimationTake, false);
    }

    private void Take()
    {
        _animator.SetBool(AnimationTake, true);
    }
}
