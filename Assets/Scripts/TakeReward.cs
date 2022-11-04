using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Agava.YandexGames;

public class TakeReward : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private HatsHanger _hanger;
    [SerializeField] private Image _panel;
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private bool _isLimitReward;
    [SerializeField] private int _limit;
    [SerializeField] private bool _isMoneyReward;
    [SerializeField] private int _money;
    [SerializeField] private bool _isHatReward;
    [SerializeField] private Hat _hat;

    private void OnEnable()
    {
        _panel.gameObject.SetActive(true);
        _button.onClick.AddListener(OnButtonClick);
        ChangeButtonText();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
        _panel.gameObject.SetActive(false);
    }

    private void ChangeButtonText()
    {
        if (_isLimitReward)
        {
            _text.text = $"{Lean.Localization.LeanLocalization.GetTranslationText("Limit")} +{_limit}";
        }
        if (_isMoneyReward)
        {
            _text.text = $"{Lean.Localization.LeanLocalization.GetTranslationText("Coins")} +{_money}";
        }
        if (_isHatReward)
        {
            _text.text = $"{Lean.Localization.LeanLocalization.GetTranslationText("Hat")} '{Lean.Localization.LeanLocalization.GetTranslationText(_hat.Name)}'";
        }
    }

    private void OnButtonClick()
    {
        VideoAd.Show();
        if (_isLimitReward)
        {
            _player.LimitUpgrade(_limit);
        }
        if (_isMoneyReward)
        {
            _player.AddMoney(_money);
        }
        if (_isHatReward)
        {
            _hanger.UnlockHat(_hat);
        }
        _button.gameObject.SetActive(false);
    }
}
