using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : RecipientContainer
{
    private int _money;
    private int _currentLimit;

    public event UnityAction Taked;
    public event UnityAction Gived;
    public event UnityAction<int> MoneyChanged;

    public int Money => _money;

    private void Start()
    {
        _money = PlayerPrefs.GetInt(Save.Money);
        _currentLimit = PlayerPrefs.GetInt(Save.Limit);

        if (_currentLimit > Limit)
        {
            LimitUpgrade(_currentLimit - Limit);
        }

        MoneyChanged?.Invoke(_money);
    }

    public void AddMoney(int money)
    {
        _money += money;
        MoneyChanged?.Invoke(_money);
    }

    public void SubMoney(int money)
    {
        _money -= money;
        MoneyChanged?.Invoke(_money);
    }

    public override Item Give(Item neededItem)
    {
        Item takedItem = base.Give(neededItem);
        if (IsEmpty)
            Gived?.Invoke();
        return takedItem;
    }

    public override void Take(Container donor)
    {
        base.Take(donor);
        if (!IsEmpty)
            Taked?.Invoke();
    }

    public override void LimitUpgrade(int increase)
    {
        base.LimitUpgrade(increase);
        _currentLimit = Limit;
    }
}
