using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTransition : Transition
{
    private void Update()
    {
        if (CurrentKnight.IsWin)
        {
            NeedTransit = true;
        }
    }
}
