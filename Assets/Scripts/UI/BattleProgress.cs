using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleProgress : MonoBehaviour
{
    [SerializeField] private Container _battle;
    [SerializeField] private Slider _progressBattle;

    private void OnEnable()
    {
        _battle.ItemsChanged += OnItemsChanged;
    }

    private void OnDisable()
    {
        _battle.ItemsChanged -= OnItemsChanged;
    }

    private void OnItemsChanged(Dictionary<Item, int> items)
    {
        int amount = 0;
        foreach (var item in items)
        {
            amount += item.Value;
        }
        ChangeSlider(amount);
    }

    private void ChangeSlider(int value)
    {
        _progressBattle.value = (float)value / (float)_battle.Limit;
    }
}
