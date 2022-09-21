using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContainerUI : MonoBehaviour
{
    [SerializeField] private Container _container;
    [SerializeField] private TextMeshProUGUI _countCargo;
    [SerializeField] private float _maxValue;

    private void OnEnable()
    {
        _container.CargoChanged += ChangeInfo;
    }

    private void OnDisable()
    {
        _container.CargoChanged -= ChangeInfo;
    }

    private void ChangeInfo(int count)
    {
        _countCargo.text = $"{count}/{_maxValue}";
    }
}
