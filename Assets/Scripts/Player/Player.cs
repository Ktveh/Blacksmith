using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : RecipientContainer
{
    [SerializeField] private int _money;

    public event UnityAction Taked;
    public event UnityAction Gived;
    public event UnityAction<int> MoneyChanged;

    public int Money => _money;

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
}
