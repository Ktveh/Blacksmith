using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullTransition : Transition
{
    private void Update()
    {
        if (CurrentKnight.IsFull)
        {
            NeedTransit = true;
        }
    }
}
