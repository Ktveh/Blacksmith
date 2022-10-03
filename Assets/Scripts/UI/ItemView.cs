using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _amount;

    public void Render(Item item, int amount)
    {
        _icon.sprite = item.Icon;
        _amount.text = amount.ToString();
    }
}
