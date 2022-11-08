using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ItemView _template;
    [SerializeField] private TextMeshProUGUI _limitAlert;

    private void OnEnable()
    {
        _player.ItemsChanged += OnItemsChanged;
    }

    private void OnDisable()
    {
        _player.ItemsChanged -= OnItemsChanged;
    }

    private void OnItemsChanged(Dictionary<Item, int> items)
    {
        ClearItemViews();
        foreach (var item in items)
        {
            if (item.Value > 0)
            {
                AddItem(item.Key, item.Value);
            }
        }
        _limitAlert.gameObject.SetActive(_player.IsFull);
    }

    private void AddItem(Item item, int amount)
    {
        var view = Instantiate(_template, transform);
        view.Render(item, amount);
    }

    private void ClearItemViews()
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
    }
}
