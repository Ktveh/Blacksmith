using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedTrigger : Trigger
{
    [SerializeField] private GameObject _activatedObject;

    protected override void Active()
    {
        _activatedObject.SetActive(true);
        base.Active();
    }
}
