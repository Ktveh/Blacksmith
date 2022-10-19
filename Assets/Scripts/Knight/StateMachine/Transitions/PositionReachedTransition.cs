using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PositionReachedTransition : Transition
{
    private void Update()
    {
        if (transform.position == CurrentKnight.Target.position)
        {
            NeedTransit = true;
        }
    }
}
