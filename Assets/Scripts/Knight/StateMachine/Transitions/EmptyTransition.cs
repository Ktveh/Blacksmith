using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EmptyTransition : Transition
{
    private void Update()
    {
        if (CurrentKnight.IsEmpty)
        {
            NeedTransit = true;
        }
    }
}
