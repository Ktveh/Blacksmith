using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ActivatedTrigger : PayTrigger
{
    [SerializeField] private GameObject _activatedObject;

    protected override void Active()
    {
        _activatedObject.SetActive(true);
        ObjectAnimation();
        base.Active();
    }

    private void ObjectAnimation()
    {
        Vector3 currentScale = _activatedObject.transform.localScale;
        _activatedObject.transform.DOScale(Vector3.zero, 0);
        _activatedObject.transform.DOScale(currentScale, 1);
    }
}
