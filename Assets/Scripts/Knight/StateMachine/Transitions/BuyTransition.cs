using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BuyTransition : Transition
{
    private void Update()
    {
        if (CurrentKnight.IsBuy)
        {
            NeedTransit = true;
        }
    }
}
