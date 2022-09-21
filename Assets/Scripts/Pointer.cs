using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private int _countTargets;
    [SerializeField] private GameObject _arrow;

    private void OnTriggerEnter(Collider other)
    {
        Trigger trigger;
        if (other.TryGetComponent<Trigger>(out trigger))
        {
            _target = trigger.GetNextTriggerTransform();
            _countTargets--;
        }
    }

    private void Update()
    {
        if (_target.gameObject.activeSelf && _countTargets > 0)
        {
            _arrow.SetActive(true);
            transform.LookAt(_target);
        }
        else
        {
            _arrow.SetActive(false);
        }
    }
}
