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

    private float _speedChangeSlider = 0.8f;
    private Coroutine _changeSliderValueJob;

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

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
        if (((float)count / (float)_knight.Limit) == 1)
        {
            float targetValue = _slider.value + _addedValue;
            StartChangeSliderValue(targetValue);
        }
    }

    private void StartChangeSliderValue(float targetValue)
    {
        if (_changeSliderValueJob != null)
            StopCoroutine(_changeSliderValueJob);
        _changeSliderValueJob = StartCoroutine(ChangeSliderValue(targetValue));
    }

    private IEnumerator ChangeSliderValue(float targetValue)
    {
        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _speedChangeSlider * Time.deltaTime);
            yield return null;
        }
    }
}
