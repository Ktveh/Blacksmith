using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : Converter
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private Animator _animator;

    private const string PressAnimation = "Press";

    public override Item Convert(Item currentItem)
    {
        Active();
        return base.Convert(currentItem);
    }

    public void Active()
    {
        _effect.Play();
        _animator.SetTrigger(PressAnimation);
    }
}
