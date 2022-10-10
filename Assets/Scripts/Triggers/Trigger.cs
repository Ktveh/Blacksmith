using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private int _needCoin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            if (player.Money >= _needCoin)
            {
                player.SubMoney(_needCoin);
                Active();
            }
        }
    }

    protected virtual void Active()
    {
        gameObject.SetActive(false);
    }
}
