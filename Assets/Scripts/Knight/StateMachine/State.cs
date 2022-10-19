using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Knight))]
public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected Knight CurrentKnight;

    private void Awake()
    {
        CurrentKnight = GetComponent<Knight>();
    }

    public State GetNextState()
    {
        foreach (Transition transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.TargetState;
            }
        }
        return null;
    }

    public void Enter()
    {
        if (!enabled)
        {
            enabled = true;
            foreach (Transition transition in _transitions)
            {
                transition.enabled = true;
            }
        }
    }

    public void Exit()
    {
        if (enabled)
        {
            foreach (Transition transition in _transitions)
            {
                transition.enabled = false;
            }
            enabled = false;
        }
    }
}
