using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private float _speed;

    private Rigidbody _rigibody;

    public event UnityAction Stopped;
    public event UnityAction Walked;

    private void Start()
    {
        _rigibody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            _rigibody.velocity = new Vector3(_joystick.Horizontal * _speed, _rigibody.velocity.y, _joystick.Vertical * _speed);
            transform.rotation = Quaternion.LookRotation(_rigibody.velocity);
            Walked?.Invoke();
        }    
        else
        {
            _rigibody.velocity = Vector3.zero;
            Stopped?.Invoke();
        }
    }
}
