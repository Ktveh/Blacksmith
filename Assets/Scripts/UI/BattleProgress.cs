using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleProgress : MonoBehaviour
{
    [SerializeField] private Container _battle;
    [SerializeField] private Slider _progressBattle;

    private Coroutine _changeSliderJob;

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
        StartChangeSlider(amount);
    }

    private void StartChangeSlider(int value)
    {
        if (_changeSliderJob != null)
        {
            StopCoroutine(_changeSliderJob);
        }
        StartCoroutine(ChangeSlider(value));
    }

    private IEnumerator ChangeSlider(int value)
    {
        float battleValue = (float)value / _battle.Limit;
        while (_progressBattle.value != battleValue)
        {
            _progressBattle.value = Mathf.MoveTowards(_progressBattle.value, battleValue, Time.deltaTime);
            yield return null;
        }
    }
}
