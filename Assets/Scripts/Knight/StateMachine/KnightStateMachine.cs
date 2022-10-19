using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Knight))]
public class KnightStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private State _currentState;

    private void Start()
    {
        Reset();
    }

    private void Update()
    {
        if (_currentState == null)
        {
            return;
        }

        State nextState = _currentState.GetNextState();
        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    private void Reset()
    {
        _currentState = _firstState;
        if (_currentState != null)
        {
            _currentState.Enter();
        }
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }
        _currentState = nextState;
        if (_currentState != null)
        {
            _currentState.Enter();
        }
    }
}
