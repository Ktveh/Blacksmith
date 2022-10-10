using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashDesk : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Image _image;
    [SerializeField] private Image _fillArea;
    [SerializeField] private Transform _clientPosition;
    [SerializeField] private Transform _spawnPosition;

    private Knight _knight;
    private bool _free;

    public bool Free => _free;
    public Transform ClientPosition => _clientPosition;

    private void Start()
    {
        _free = true;
    }

    public void Reserve()
    {
        _free = false;
    }

    public void SetBusy(Knight knight)
    {
        _knight = knight;
        _knight.ItemsChanged += ChangeInfo;
        _canvas.gameObject.SetActive(true);
        _fillArea.fillAmount = 0;
        _image.sprite = _knight.ArmorSign;
    }

    public void SetFree()
    {
        _knight.ItemsChanged -= ChangeInfo;
        _free = true;
        _canvas.gameObject.SetActive(false);
        _knight = null;
    }

    public void ChangeInfo(Dictionary<Item, int> amountItems)
    {
        int amount = 0;
        foreach (var item in amountItems)
        {
            amount += item.Value;
        }

        _fillArea.fillAmount = (float)amount / (float)_knight.Limit;

        if (_knight.IsFull)
        {
            SetFree();
        }
    }
}
