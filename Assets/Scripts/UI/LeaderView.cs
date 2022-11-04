using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _place;

    public void Render(string name, string score, string place)
    {
        _name.text = name;
        _score.text = score;
        _place.text = place;
    }
}
