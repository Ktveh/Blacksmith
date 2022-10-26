using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _newGameButton;

    private const int _startMoney = 0;
    private const int _startLimit = 4;
    private const int _startLevel = 1;

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(OnContinueButtonClick);
        _newGameButton.onClick.AddListener(OnNewGameButtonClick);

        if (!PlayerPrefs.HasKey(Save.Level))
        {
            _continueButton.enabled = false;
        }
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(OnContinueButtonClick);
        _newGameButton.onClick.RemoveListener(OnNewGameButtonClick);
    }

    private void OnContinueButtonClick()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt(Save.Level));
    }

    private void OnNewGameButtonClick()
    {
        PlayerPrefs.SetInt(Save.Money, _startMoney);
        PlayerPrefs.SetInt(Save.Limit, _startLimit);
        PlayerPrefs.SetInt(Save.Level, _startLevel);

        SceneManager.LoadScene(PlayerPrefs.GetInt(Save.Level));
    }
}
