using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleFinal : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objectsForDisable;
    [SerializeField] private List<Knight> _knights;
    [SerializeField] private ParticleSystem _winEffect;
    [SerializeField] private Container _battle;
    [SerializeField] private Image _rewardPanel;

    private void OnEnable()
    {
        _battle.ItemsChanged += CheckBattle;
    }

    private void OnDisable()
    {
        _battle.ItemsChanged -= CheckBattle;
    }

    private void CheckBattle(Dictionary<Item, int> items)
    {
        int amount = 0;
        foreach (var item in items)
        {
            amount += item.Value;
        }

        if (amount >= _battle.Limit)
        {
            EndBattle();
        }
    }

    private void EndBattle()
    {
        _winEffect.Play();

        foreach (GameObject objectForDisable in _objectsForDisable)
        {
            objectForDisable.gameObject.SetActive(false);
        }

        foreach (Knight knight in _knights)
        {
            knight.Win();
        }

        _rewardPanel.gameObject.SetActive(true);
    }
}
