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
    [SerializeField] private Coin _coin;

    private Knight _knight;
    private bool _free;

    private const float Indent = 0.1f;
    private const float MoneyPow = 0.5f;

    public bool IsReady => _knight != null;
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
        _canvas.gameObject.SetActive(false);
        TakeCoin(_knight.Limit);
        _knight.ItemsChanged -= ChangeInfo;
        _knight = null;
        _free = true;
    }

    public void ChangeInfo(Dictionary<Item, int> amountItems)
    {
        int amount = 0;
        foreach (var item in amountItems)
        {
            amount += item.Value;
        }

        _fillArea.fillAmount = (float)amount / (float)_knight.Limit;
    }

    private void TakeCoin(float amount)
    {
        Vector3 _startSpawnPosition = _spawnPosition.position;
        amount += amount * MoneyPow * PlayerPrefs.GetInt(Save.Difficulty);

        for (int i = 0; i < amount; i++)
        {
            _spawnPosition.position = new Vector3(_spawnPosition.position.x, _spawnPosition.position.y + i * Indent, _spawnPosition.position.z);
            Instantiate(_coin, _spawnPosition.position, Quaternion.identity);
        }
        _spawnPosition.position = _startSpawnPosition;
    }
}
