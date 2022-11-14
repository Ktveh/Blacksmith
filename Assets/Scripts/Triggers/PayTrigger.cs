using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PayTrigger : MonoBehaviour
{
    [SerializeField] private int _needCoin;
    [SerializeField] private Image _fillImage;
    [SerializeField] private float _fillSpeed;
    [SerializeField] private TextMeshProUGUI _price;

    private Player _player;
    private Coroutine _fillTriggerJob;

    private const int MoneyPow = 10;

    public int NeedCoin => _needCoin;

    private void Start()
    {
        _needCoin += MoneyPow * PlayerPrefs.GetInt(Save.Difficulty);
        _price.text = _needCoin.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out _player))
        {
            CheckPlayerMoney();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out _player))
        {
            StartFillTrigger(0);
        }
    }

    protected virtual void Active()
    {
        _player.SubMoney(_needCoin);
        gameObject.SetActive(false);
    }

    private void CheckPlayerMoney()
    {
        if (_player.Money >= _needCoin)
        {
            StartFillTrigger(1);
        }
    }

    private void StartFillTrigger(float targetValue)
    {
        if (_fillTriggerJob != null)
        {
            StopCoroutine(_fillTriggerJob);
        }
        _fillTriggerJob = StartCoroutine(FillTrigger(targetValue));
    }

    private IEnumerator FillTrigger(float targetValue)
    {
        while (_fillImage.fillAmount != targetValue)
        {
            _fillImage.fillAmount = Mathf.MoveTowards(_fillImage.fillAmount, targetValue, _fillSpeed * Time.deltaTime);
            if (_fillImage.fillAmount == 1)
            {
                Active();
            }
            yield return null;
        }
    } 
}
