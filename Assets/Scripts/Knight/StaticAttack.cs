using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticAttack : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string AnimationAttack = "Battle";

    private void Start()
    {
        _animator.SetBool(AnimationAttack, true);
    }
}
