using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Knight))]
public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected Knight CurrentKnight;

    public bool NeedTransit { get; protected set; }

    public State TargetState => _targetState;

    private void Awake()
    {
        CurrentKnight = GetComponent<Knight>();
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
