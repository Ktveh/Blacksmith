using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTrigger : Trigger
{
    [SerializeField] private IUpgrade _upgradeObject;

    protected override void Active()
    {
        _upgradeObject.Upgrade();
        base.Active();
    }
}
