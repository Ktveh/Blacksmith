using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Canvas _mainCanvas;
    [SerializeField] private Trigger _firstTrigger;
    [SerializeField] private CameraMover _titleCamera;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _newGameButton;

    private const int StartMoney = 0;
    private const int StartLimit = 4;
    private const int StartLevel = 1;

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
        _player.gameObject.SetActive(true);
        _mainCanvas.gameObject.SetActive(true);
        _firstTrigger.gameObject.SetActive(true);
        _titleCamera.StartMove();
        _continueButton.onClick.RemoveListener(OnContinueButtonClick);
        _newGameButton.onClick.RemoveListener(OnNewGameButtonClick);
    }

    private void OnContinueButtonClick()
    {
        int level = PlayerPrefs.GetInt(Save.Level);
        if (level == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt(Save.Level));
        }
    }

    private void OnNewGameButtonClick()
    {
        PlayerPrefs.SetInt(Save.Money, StartMoney);
        PlayerPrefs.SetInt(Save.Limit, StartLimit);
        PlayerPrefs.SetInt(Save.Level, StartLevel);
        gameObject.SetActive(false);
    }
}
