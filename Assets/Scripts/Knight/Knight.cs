using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Knight : RecipientContainer
{
    [SerializeField] private Armor _armor;
    [SerializeField] private Sprite _armorSign;
    [SerializeField] private Transform _battlePosition;
    [SerializeField] private Transform _middlePosition;
    [SerializeField] private Shop _shop;

    private CashDesk _cashDesk;
    private Transform _target;
    private bool _isWin;
    private bool _isBuy;

    public Sprite ArmorSign => _armorSign;
    public bool IsWin => _isWin;
    public bool IsBuy => _isBuy;
    public Transform Target => _target;
    public Transform MiddlePosition => _middlePosition;

    private void Start()
    {
        _isWin = false;
        _isBuy = false;
        ReportChange();
        PlaceItems();
    }

    public bool TryFindCashDesk()
    {
        if (_shop.TryFreePosition(out _cashDesk))
        {
            _cashDesk.Reserve();
            _target = _cashDesk.ClientPosition;
            _armor.gameObject.SetActive(false);
            _isBuy = true;
            return true;
        }
        return false;
    }

    public void SetBusyCashDesk()
    {
        if (_cashDesk != null)
        {
            transform.LookAt(_cashDesk.transform);
            _cashDesk.SetBusy(this);
            ReportChange();
        }
    }

    public void TakeArmor()
    {
        _isBuy = false;
        _cashDesk.SetFree();
        _armor.gameObject.SetActive(true);
        _target = _battlePosition;
    }

    public void Win()
    {
        _isWin = true;
    }
}
