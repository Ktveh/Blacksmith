using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Container
{
    [SerializeField] float _delay;

    private int _money = 10;
    private float _ellapsedTime = 0;

    public event UnityAction Taked;
    public event UnityAction Gived;
    public event UnityAction<int> MoneyChanged;
    public event UnityAction<int> OreChanged;
    public event UnityAction<int> SwordChanged;

    private void OnTriggerStay(Collider other)
    {
        _ellapsedTime += Time.deltaTime;

        if (_ellapsedTime > _delay)
        {
            Container container;
            if (other.TryGetComponent<Container>(out container))
            {
                if (container.IsDonor)
                {
                    Take(container);
                }
                else if (!container.IsDonor)
                {
                    container.Take(this);
                }
                _ellapsedTime = 0;
            }
        }
    }

    public override Cargo Give()
    {
        Cargo cargo = base.Give();
        ChangeCargo();
        return cargo;
    }

    public override void Take(Container donor)
    {
        base.Take(donor);
        ChangeCargo();
    }

    public void AddMoney()
    {
        _money++;
        MoneyChanged?.Invoke(_money);
    }

    private void ChangeCargo()
    {
        if (Cargos.Count > 0)
        {
            Taked?.Invoke();
            if (Cargos[0].IsChanged)
                SwordChanged?.Invoke(Cargos.Count);
            else
                OreChanged?.Invoke(Cargos.Count);
        }
        else
        {
            Gived?.Invoke();
            SwordChanged?.Invoke(Cargos.Count);
            OreChanged?.Invoke(Cargos.Count);
        }
    }
}
