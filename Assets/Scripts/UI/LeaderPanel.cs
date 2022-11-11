using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Agava.YandexGames;

public class LeaderPanel : MonoBehaviour
{
    [SerializeField] private GameObject _content;
    [SerializeField] private LeaderView _template;

    private void OnEnable()
    {
        ShowLeaders();
    }

    private void OnDisable()
    {
        foreach (Transform child in _content.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void ShowLeaders()
    {
        if (!PlayerAccount.IsAuthorized)
        {
            PlayerAccount.Authorize();
        }

        Leaderboard.GetEntries("PlaytestBoard", (result) =>
        {
            Debug.Log($"My rank = {result.userRank}");
            foreach (var entry in result.entries)
            {
                string name = entry.player.publicName;
                if (string.IsNullOrEmpty(name))
                    name = "Anonymous";
                int score = entry.score;
                int place = entry.rank;
                if (place > 15)
                    break;
                AddLeader(name, score, place);
                Debug.Log(name + " " + entry.score);
            }
        });
        
    }

    private void AddLeader(string name, int score, int place)
    {
        var view = Instantiate(_template, _content.transform);
        view.Render(name, score.ToString(), place.ToString());
    }
}
