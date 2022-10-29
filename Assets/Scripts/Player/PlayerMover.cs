using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private float _speed;

    private Coroutine _changeVectorJob;
    private Rigidbody _rigibody;
    private float _horizontalVector;
    private float _verticalVector;

    private const float VectorStep = 4f;

    public event UnityAction Stopped;
    public event UnityAction Walked;

    private void Start()
    {
        _rigibody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        CheckVector();
        if (_horizontalVector != 0 || _verticalVector != 0)
        {
            _rigibody.velocity = new Vector3(_horizontalVector * _speed, _rigibody.velocity.y, _verticalVector * _speed);
            transform.rotation = Quaternion.LookRotation(_rigibody.velocity);
            Walked?.Invoke();
        }    
        else
        {
            _rigibody.velocity = Vector3.zero;
            Stopped?.Invoke();
        }
    }

    private void CheckVector()
    {
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            _horizontalVector = _joystick.Horizontal;
            _verticalVector = _joystick.Vertical;
            return;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            ChangeValueVector(new Vector2(_horizontalVector, 1));
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            ChangeValueVector(new Vector2(_horizontalVector, -1));
        }
        else
        {
            ChangeValueVector(new Vector2(_horizontalVector, 0));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            ChangeValueVector(new Vector2(1, _verticalVector));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            ChangeValueVector(new Vector2(-1, _verticalVector));
        }
        else
        {
            ChangeValueVector(new Vector2(0, _verticalVector));
        }
    }

    private void ChangeValueVector(Vector2 vector)
    {
        _horizontalVector = Mathf.MoveTowards(_horizontalVector, vector.x, VectorStep * Time.deltaTime);
        _verticalVector = Mathf.MoveTowards(_verticalVector, vector.y, VectorStep * Time.deltaTime);
    }
}
