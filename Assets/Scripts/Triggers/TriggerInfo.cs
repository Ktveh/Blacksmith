using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private Trigger _trigger;

    private void Start()
    {
        _price.text = _trigger.NeedCoin.ToString();
    }
}
