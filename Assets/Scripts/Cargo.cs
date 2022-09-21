using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour
{
    [SerializeField] private GameObject _startObject;
    [SerializeField] private GameObject _finishObject;

    private bool _isChanged = false;

    public bool IsChanged => _isChanged;

    public void Change()
    {
        _finishObject.SetActive(true);
        _startObject.SetActive(false);
        _isChanged = true;
    }
}
