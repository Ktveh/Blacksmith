using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameInfo : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Knight _knight;
    [SerializeField] private Image _moneyPanel;
    [SerializeField] private Image _orePanel;
    [SerializeField] private Image _swordPanel;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _addedValue;
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _oreText;
    [SerializeField] private TextMeshProUGUI _swordText;

    private void OnEnable()
    {
        _knight.CargoChanged += CahngeSlider;
        _player.OreChanged += ChangeOreInfo;
        _player.SwordChanged += ChangeSwordInfo;
        _player.MoneyChanged += ChangeMoneyInfo;
    }

    private void OnDisable()
    {
        _knight.CargoChanged -= CahngeSlider;
        _player.OreChanged -= ChangeOreInfo;
        _player.SwordChanged -= ChangeSwordInfo;
        _player.MoneyChanged -= ChangeMoneyInfo;
    }

    private void ChangeMoneyInfo(int count)
    {
        _moneyPanel.gameObject.SetActive(count > 0);
        _moneyText.text = count.ToString();
    }

    private void ChangeOreInfo(int count)
    {
        _orePanel.gameObject.SetActive(count > 0);
        _oreText.text = count.ToString();
    }

    private void ChangeSwordInfo(int count)
    {
        _swordPanel.gameObject.SetActive(count > 0);
        _swordText.text = count.ToString();
    }

    private void CahngeSlider(int count)
    {
        if (((float)count / (float)_knight.NeedSwords) == 1)
        {
            _slider.value += _addedValue;
        }
    }
}
