using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : Converter
{
    [SerializeField] private ParticleSystem _effect;

    public override Item Convert(Item currentItem)
    {
        Active();
        return base.Convert(currentItem);
    }

    public void Active()
    {
        _effect.Play();
    }
}
