using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class KnightMover : MonoBehaviour
{
    [SerializeField] private Knight _knight;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateDuration;

    private Coroutine _moveJob;

    public event UnityAction Stopped;
    public event UnityAction Walked;

    private void OnEnable()
    {
        _knight.Moved += StartMove;
    }

    private void OnDisable()
    {
        _knight.Moved -= StartMove;
    }

    private void StartMove(Transform target)
    {
        transform.DOLookAt(target.position, _rotateDuration);
        if (_moveJob != null)
            StopCoroutine(_moveJob);
        _moveJob = StartCoroutine(Move(target));
        Walked?.Invoke();
    }

    private IEnumerator Move(Transform target)
    {
        while(transform.position != target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
            yield return null;
        }
        Stopped?.Invoke();
    }
}
