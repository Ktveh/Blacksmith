using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Transporter : Container
{
    [SerializeField] private Transform _finishElementPosition;
    [SerializeField] private Container _donor;
    [SerializeField] private Container _target;
    [SerializeField] private Press _press;
    [SerializeField] private float _delay;
    [SerializeField] private bool _isPress;

    private float _ellapsedTime = 0;
    private float _startPositionZ;

    private void Start()
    {
        _startPositionZ = FirstElementPosition.position.z;
    }

    private void Update()
    {
        _ellapsedTime += Time.deltaTime;
        if (IsEmpty)
        {
            _ellapsedTime = 0;
            Take(_donor);
            FirstElementPosition.transform.DOMoveZ(_startPositionZ, 0);
            FirstElementPosition.transform.DOMoveZ(_finishElementPosition.position.z, 0.5f).SetLoops(-1).SetSpeedBased(true);
            if (_isPress && !IsEmpty)
            {
                //Items[0].Change();
            }
            
        }
        if (_ellapsedTime > _delay)
        {
            _target.Take(this);
            if (!_isPress)
            {
                _press.Active();
            }
        }
    }
}
