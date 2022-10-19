using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmountView : MonoBehaviour
{
    [SerializeField] private Container _container;
    [SerializeField] private TextMeshProUGUI _valueTMPro;

    private void OnEnable()
    {
        _container.ItemsChanged += Change;
    }

    private void OnDisable()
    {
        _container.ItemsChanged -= Change;
    }

    private void Change(Dictionary<Item, int> items)
    {
        int amount = 0;
        foreach (var item in items)
        {
            amount += item.Value;
        }

        _valueTMPro.text = $"{amount}/{_container.Limit}";
    }
}
