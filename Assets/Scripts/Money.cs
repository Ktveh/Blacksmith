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

    private Rigidbody _rigibody;
    private Player _target;
    private float _durationMove = 0.8f;
    private float _delayMove = 1f;
    private float _minForce = 0.4f;
    private float _maxForce = 0.6f;
    private bool _isTaked = false;

    public bool IsTaked => _isTaked;

    private void Start()
    {
        _rigibody = GetComponent<Rigidbody>();
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
        Vector3 force = new Vector3(CreateRandomDirection(), _forceUp, CreateRandomDirection());
        _rigibody.AddForce(force, ForceMode.Impulse);
        transform.DOMove(_target.transform.position, _durationMove).SetDelay(_delayMove).SetAutoKill(false);
    }

    private float CreateRandomDirection()
    {
        float direction = Random.Range(-_maxForce, _maxForce);
        if (direction < 0)
            direction -= _minForce;
        else
            direction += _minForce;
        return direction;
    }
}
