using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PayTrigger : MonoBehaviour
{
    [SerializeField] private int _needCoin;
    [SerializeField] private Image _questionImage;
    [SerializeField] private Button _yesButon;
    [SerializeField] private Button _noButon;
    [SerializeField] private TextMeshProUGUI _questionTMPro;

    private Player _player;

    public int NeedCoin => _needCoin;

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
            CloseQuestion();
        }
    }

    private void CheckPlayerMoney()
    {
        if (_player.Money >= _needCoin)
        {
            if (_needCoin > 0)
            {
                OpenQuestion();
            }
            else
            {
                Active();
            }
        }
    }

    private void OpenQuestion()
    {
        _questionImage.gameObject.SetActive(true);
        _yesButon.onClick.AddListener(Active);
        _noButon.onClick.AddListener(CloseQuestion);
        _questionTMPro.text = $"{Lean.Localization.LeanLocalization.GetTranslationText("Buy for")} {_needCoin}";
    }

    protected virtual void Active()
    {
        _player.SubMoney(_needCoin);
        gameObject.SetActive(false);
        CloseQuestion();
    }

    private void CloseQuestion()
    {
        if (_questionImage.IsActive())
        {
            _yesButon.onClick.RemoveListener(Active);
            _noButon.onClick.RemoveListener(CloseQuestion);
            _questionImage.gameObject.SetActive(false);
        }
    }
}
