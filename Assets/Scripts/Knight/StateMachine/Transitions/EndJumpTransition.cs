using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndJumpTransition : Transition
{
    [SerializeField] private float _jumpDelay;

    private float _ellapsedTime;

    private void Start()
    {
        _ellapsedTime = 0;
    }

    private void Update()
    {
        _ellapsedTime += Time.deltaTime;
        if (_ellapsedTime >= _jumpDelay)
        {
            NeedTransit = true;
        }
    }
}
