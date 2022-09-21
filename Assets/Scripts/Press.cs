using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Press : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    private Animator _animator;

    private const string PressAnimation = "Press";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Cargo>())
            Active();
    }

    public void Active()
    {
        _effect.Play();
        _animator.SetTrigger(PressAnimation);
    }
}
