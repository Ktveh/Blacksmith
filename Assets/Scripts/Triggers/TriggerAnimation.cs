using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TriggerAnimation : MonoBehaviour
{
    [SerializeField] private bool _isRotate;
    [SerializeField] private Vector3 _rotate;
    [SerializeField] private bool _isFloat;
    [SerializeField] private float _distanceFloat;
    [SerializeField] private float _speedFloat;

    private void Start()
    {
        if (_isFloat)
        {
            transform.DOMoveY(transform.position.y + _distanceFloat, _speedFloat).SetLoops(-1, LoopType.Yoyo).SetSpeedBased(true);
        }
    }

    private void Update()
    {
        if (_isRotate)
        {
            transform.Rotate(_rotate);
        }
    }
}
