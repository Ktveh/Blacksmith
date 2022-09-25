using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Animator))]
public class BattleKnight : MonoBehaviour
{
    [SerializeField] private float _minDuration;
    [SerializeField] private float _maxDuration;
    [SerializeField] private float _minAngleRotate;
    [SerializeField] private float _maxAngleRotate;
    [SerializeField] private float _minDistance;
    [SerializeField] private float _maxDistance;

    private float _ellapsedTime;
    private float _duration;
    private Animator _animator;

    private const float MinPositionX = 4;
    private const float MaxPositionX = 9;
    private const float MinPositionZ = 17;
    private const float MaxPositionZ = 23;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        SetNewDuration();
    }

    private void Update()
    {
        _ellapsedTime += Time.deltaTime;
        if (_ellapsedTime > _duration)
        {
            _ellapsedTime = 0;
            transform.DORotate(new Vector3(0, Random.Range(_minAngleRotate, _maxAngleRotate), 0), _duration);
            transform.DOMove(new Vector3(SetDistantion(transform.position.x), transform.position.y, SetDistantion(transform.position.z)), _duration);
            _animator.speed = _duration;
            SetNewDuration();
        }
        CheckPosition();
    }

    private float SetDistantion(float positionPoint)
    {
        return positionPoint + Random.Range(-_maxDistance, _maxDistance);
        if (positionPoint < 0)
            positionPoint -= _minDistance;
        else
            positionPoint += _minDistance;
        return positionPoint;
    }

    private void SetNewDuration()
    {
        _duration = Random.Range(_minDuration, _maxDuration);
    }

    private void CheckPosition()
    {
        float newPositionX = transform.position.x;
        float newPositionZ = transform.position.z;
        if (transform.position.x > MaxPositionX)
            newPositionX = MaxPositionX;
        if (transform.position.x < MinPositionX)
            newPositionX = MinPositionX;
        if (transform.position.z > MaxPositionZ)
            newPositionZ = MaxPositionZ;
        if (transform.position.z < MinPositionZ)
            newPositionZ = MinPositionZ;
        transform.position = new Vector3(newPositionX, transform.position.y, newPositionZ);
    }
}
