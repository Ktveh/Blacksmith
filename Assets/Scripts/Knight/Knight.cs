using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Knight : Container
{
    [SerializeField] private int _amountMoney;
    [SerializeField] private Armor _armor;
    [SerializeField] private Sprite _armorSign;
    [SerializeField] private Transform _battlePosition;
    [SerializeField] private Transform _middlePosition;
    [SerializeField] private Shop _shop;
    [SerializeField] private BattleKnight _battleKnight;

    private CashDesk _cashDesk;

    public Sprite ArmorSign => _armorSign;

    public event UnityAction Jumped;
    public event UnityAction<bool> Attacked;
    public event UnityAction<Transform> Moved;

    private void Start()
    {
        ReportChange();
        PlaceItems();
    }

    private void Update()
    {
        CheckPosition();
    }

    protected override void PlaceItems()
    {
        base.PlaceItems();
        CheckPosition();
    }

    private void CheckPosition()
    {
        if (IsEmpty)
        {
            if (_cashDesk == null)
            {
                if (_shop.TryFreePosition(out _cashDesk))
                {
                    _cashDesk.Reserve();
                    _armor.gameObject.SetActive(false);
                    _battleKnight.enabled = false;
                    Attacked?.Invoke(false);
                    Moved?.Invoke(_middlePosition);
                }
                else
                {
                    Attacked?.Invoke(true);
                    _battleKnight.enabled = true;
                }
            }
            else
            {
                if (IsReachedPosition(_middlePosition))
                {
                    Moved?.Invoke(_cashDesk.ClientPosition);
                }
                if (IsReachedPosition(_cashDesk.ClientPosition))
                {
                    _cashDesk.SetBusy(this);
                }
            }
        }
        if (IsFull)
        {
            if (_cashDesk != null)
            {
                if (IsReachedPosition(_cashDesk.ClientPosition))
                {
                    _cashDesk = null;
                    _armor.gameObject.SetActive(true);
                    Jumped?.Invoke();
                    Moved?.Invoke(_middlePosition);
                }
            }
            if (IsReachedPosition(_middlePosition))
            {
                Moved?.Invoke(_battlePosition);
            }
            if (IsReachedPosition(_battlePosition))
            {
                _battleKnight.enabled = true;
                Attacked?.Invoke(true);
            }
        }
    }

    private bool IsReachedPosition(Transform neededPosition)
    {
        return transform.position == neededPosition.position;
    }
}
