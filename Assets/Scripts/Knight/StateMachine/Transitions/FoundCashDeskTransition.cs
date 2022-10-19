using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundCashDeskTransition : Transition
{
    private void Update()
    {
        if (CurrentKnight.IsEmpty && CurrentKnight.TryFindCashDesk())
        {
            NeedTransit = true;
        }
    }
}
