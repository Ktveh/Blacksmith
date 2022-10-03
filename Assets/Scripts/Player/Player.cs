using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Container
{
    private int _money = 10;

    public event UnityAction Taked;
    public event UnityAction Gived;
    public event UnityAction<int> MoneyChanged;

    public void AddMoney()
    {
        _money++;
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
