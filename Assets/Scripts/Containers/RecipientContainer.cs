using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipientContainer : Container
{
    [SerializeField] private bool _isBattle;

    private const int DifficultyPow = 10;

    private void Start()
    {
        if (_isBattle)
        {
            LimitUpgrade(PlayerPrefs.GetInt(Save.Difficulty) * DifficultyPow);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        EllapsedTime += Time.deltaTime;

        Container container;
        if (EllapsedTime > Delay && other.TryGetComponent<Container>(out container))
        {
            CheckDonors(container);
            EllapsedTime = 0;
        }
    }
}
