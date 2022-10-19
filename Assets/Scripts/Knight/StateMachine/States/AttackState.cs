using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AttackState : State
{
    [SerializeField] private float _minDuration;
    [SerializeField] private float _maxDuration;
    [SerializeField] private float _minAngleRotate;
    [SerializeField] private float _maxAngleRotate;
    [SerializeField] private float _maxDistance;
    [SerializeField] private Transform _battlePosition;
    [SerializeField] private float _radiusBattle;
    [SerializeField] private Animator _animator;

    private float _ellapsedTime;
    private float _duration;

    private const string AnimationBattle = "Battle";

    private void OnEnable()
    {
        _animator.SetBool(AnimationBattle, true);
        _animator.speed = 1;
        SetNewDuration();
    }

    private void OnDisable()
    {
        _animator.SetBool(AnimationBattle, false);
    }

    private void Update()
    {
        _ellapsedTime += Time.deltaTime;
        if (_ellapsedTime > _duration)
        {
            _ellapsedTime = 0;
            transform.DORotate(new Vector3(0, Random.Range(_minAngleRotate, _maxAngleRotate), 0), _duration);
            transform.DOMove(new Vector3(SetNewDistantion(transform.position.x), transform.position.y, SetNewDistantion(transform.position.z)), _duration);
            _animator.speed = _duration;
            SetNewDuration();
        }
        CheckPosition();
    }

    private float SetNewDistantion(float positionPoint)
    {
        return positionPoint + Random.Range(-_maxDistance, _maxDistance);
    }

    private void SetNewDuration()
    {
        _duration = Random.Range(_minDuration, _maxDuration);
    }

    private void CheckPosition()
    {
        float currentRadius = Vector3.Distance(transform.position, _battlePosition.position);
        if (currentRadius > _radiusBattle)
        {
            transform.position = Vector3.MoveTowards(transform.position, _battlePosition.position, Time.deltaTime);
        }
    }
}
