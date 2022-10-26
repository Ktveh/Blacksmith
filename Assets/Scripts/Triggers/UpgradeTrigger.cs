using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UpgradeTrigger : PayTrigger
{
    [SerializeField] private Container _upgradeContainer;
    [SerializeField] private bool _isLimitUpgrade;
    [SerializeField] private int _limitIncrease;
    [SerializeField] private bool _isDelayUpgrade;
    [SerializeField] private float _delayDecrease;

    protected override void Active()
    {
        Upgrade();
        base.Active();
    }

    private void Upgrade()
    {
        if (_isLimitUpgrade)
        {
            _upgradeContainer.LimitUpgrade(_limitIncrease);
        }
        if (_isDelayUpgrade)
        {
            _upgradeContainer.DelayUpgrade(_delayDecrease);
        }
        ObjectAnimation();
    }

    private void ObjectAnimation()
    {
        Vector3 currentScale = _upgradeContainer.transform.localScale;
        _upgradeContainer.transform.DOScale(currentScale*1.2f, 0.3f).SetLoops(2, LoopType.Yoyo);
    }
}
