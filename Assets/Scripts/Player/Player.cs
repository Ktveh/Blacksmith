using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : RecipientContainer
{
    [SerializeField] private AudioSource AudioCoin;
    [SerializeField] private AudioSource AudioTake;
    [SerializeField] private List<Hat> _hats;

    private int _money;
    private int _currentLimit;
    private string _currentHat;

    public event UnityAction Taked;
    public event UnityAction Gived;
    public event UnityAction<int> MoneyChanged;

    public int Money => _money;
    public string CurrentHat => _currentHat;

    private void Start()
    {
        _money = PlayerPrefs.GetInt(Save.Money);
        _currentLimit = PlayerPrefs.GetInt(Save.Limit);
        _currentHat = PlayerPrefs.GetString(Save.CurrentHat);
        ChangeHat(_currentHat);

        if (_currentLimit > Limit)
        {
            LimitUpgrade(_currentLimit - Limit);
        }

        MoneyChanged?.Invoke(_money);
    }

    public void AddMoney(int money)
    {
        ChangeAmountMoney(money);
    }

    public void SubMoney(int money)
    {
        ChangeAmountMoney(-money);
    }

    private void ChangeAmountMoney(int value)
    {
        _money += value;
        MoneyChanged?.Invoke(_money);
        AudioCoin.Play();
    }

    public void ChangeHat(string hatName)
    {
        foreach (Hat hat in _hats)
        {
            hat.gameObject.SetActive(false);
            if (hat.Name == hatName)
            {
                _currentHat = hat.Name;
                hat.gameObject.SetActive(true);
                PlayerPrefs.SetString(Save.CurrentHat, _currentHat);
            }
        }
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
        {
            Taked?.Invoke();
        }
    }

    public override void LimitUpgrade(int increase)
    {
        base.LimitUpgrade(increase);
        _currentLimit = Limit;
    }

    protected override void PlaceItems()
    {
        AudioTake.Play();
        base.PlaceItems();
    }
}
