using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private Player _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out _player))
        {
            Active();
        }
    }

    protected virtual void Active()
    {
        gameObject.SetActive(false);
    }
}
