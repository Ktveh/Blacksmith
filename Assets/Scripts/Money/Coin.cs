using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Coin : MonoBehaviour
{
    [SerializeField] BoxCollider _jumpCollider;
    [SerializeField] BoxCollider _takeCollider;

    private Rigidbody _rigibody;
    private Player _target;
    private bool _isTaked;
    private float _speed;

    private const float TargetPositionShift = 1f;
    private const float SpeedMultiplier = 8f;
    private const float ForceUp = 12f;
    private const float MinForce = 0.4f;
    private const float MaxForce = 0.8f;

    private void Start()
    {
        _rigibody = GetComponent<Rigidbody>();
        _isTaked = false;
    }

    private void Update()
    {
        if (_isTaked)
        {
            _speed += SpeedMultiplier * Time.deltaTime;
            MoveToPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isTaked)
        {
            if (other.TryGetComponent<Player>(out _target))
            {
                _isTaked = true;
                _jumpCollider.enabled = false;
                _takeCollider.isTrigger = true;
                Jump();
                MoveToPlayer();
            }
        }
        else
        {
            if (other.GetComponent<Player>())
            {
                _target.AddMoney(1);
                Destroy(gameObject);
            }
        }
    }

    private void Jump()
    {
        Vector3 force = new Vector3(CreateRandomDirection(), ForceUp, CreateRandomDirection());
        _rigibody.AddForce(force, ForceMode.Impulse);
        _speed = 0;
    }

    private float CreateRandomDirection()
    {
        float direction = Random.Range(-MaxForce, MaxForce);
        if (direction < 0)
            direction -= MinForce;
        else
            direction += MinForce;
        return direction;
    }

    private void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, SetTargetPosition(), _speed * Time.deltaTime);
    }

    private Vector3 SetTargetPosition()
    {
        return new Vector3(_target.transform.position.x, _target.transform.position.y + TargetPositionShift, _target.transform.position.z);
    }
}
