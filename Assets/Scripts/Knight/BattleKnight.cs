using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BattleKnight : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _minAngleRotate;
    [SerializeField] private float _maxAngleRotate;
    [SerializeField] private float _minDistance;
    [SerializeField] private float _maxDistance;

    private float _ellapsedTime;

    private void Update()
    {
        _ellapsedTime += Time.deltaTime;
        if (_ellapsedTime > _delay)
        {
            _ellapsedTime = 0;
            transform.DORotate(new Vector3(0, Random.Range(_minAngleRotate, _maxAngleRotate), 0), _delay);
            transform.DOMoveZ(transform.position.z + Random.Range(_minDistance, _maxDistance), _delay);
            transform.DOMoveX(transform.position.x + Random.Range(_minDistance, _maxDistance), _delay);
        }
    }
}
