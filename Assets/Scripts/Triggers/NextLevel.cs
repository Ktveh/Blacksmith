using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Agava.YandexGames;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private int _nextScene;

    private Player _player;

    private const int LastLevel = 7;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out _player))
        {
            SaveProgress();
            InterstitialAd.Show();
            SceneManager.LoadScene(_nextScene);
        }
    }

    private void SaveProgress()
    {
        Leaderboard.GetPlayerEntry("PlaytestBoard", (result) =>
        {
            if (result == null || result.score < _player.Money)
            {
                Leaderboard.SetScore("PlaytestBoard", _player.Money);
            }
        });

        if (PlayerPrefs.GetInt(Save.Level) == LastLevel)
        {
            int newDifficulty = PlayerPrefs.GetInt(Save.Difficulty) + 1;
            PlayerPrefs.SetInt(Save.Difficulty, newDifficulty);
        }

        PlayerPrefs.SetInt(Save.Money, _player.Money);
        PlayerPrefs.SetInt(Save.Limit, _player.Limit);
        PlayerPrefs.SetInt(Save.Level, _nextScene);
        PlayerPrefs.SetString(Save.CurrentHat, _player.CurrentHat);
    }
}
