using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class Money : MonoBehaviour
{
    [SerializeField] private float _forceUp;
    [SerializeField] BoxCollider _jumpCollider;
    [SerializeField] BoxCollider _takeCollider;

    private Tweener _tween;
    private Rigidbody _rigibody;
    private Player _target;
    private Vector3 _lastTargetPosition;
    private float _dirationMove = 0.8f;
    private float _delayMove = 0.6f;
    private float _minForce = -0.8f;
    private float _maxForce = 0.8f;
    private bool _isTaked = false;

    public bool IsTaked => _isTaked;

    private void Start()
    {
        _rigibody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_target != null)
        {
            if (_isTaked && (_target.transform.position != _lastTargetPosition))
            {
                _tween.ChangeEndValue(_target.transform.position, true).Restart();
                _lastTargetPosition = _target.transform.position;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out _target))
        {
            if (!_isTaked)
            {
                _isTaked = true;
                _jumpCollider.enabled = false;
                _takeCollider.isTrigger = true;
                MoveToPlayer();
            }
            else
            {
                _target.AddMoney();
                Destroy(gameObject);
            }
        }
    }

    private void MoveToPlayer()
    {
        Vector3 force = new Vector3(Random.Range(_minForce, _maxForce), _forceUp, Random.Range(_minForce, _maxForce));
        _rigibody.AddForce(force, ForceMode.Impulse);
        _tween = transform.DOMove(_target.transform.position, _dirationMove).SetDelay(_delayMove).SetAutoKill(false);
        _lastTargetPosition = _target.transform.position;
    }
}
