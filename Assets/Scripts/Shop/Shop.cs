using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<CashDesk> _cashDesks;

    public bool TryFreePosition(out CashDesk freeCashDesk)
    {
        freeCashDesk = null;
        foreach(CashDesk cashDesk in _cashDesks)
        {
            if (cashDesk.Free)
            {
                freeCashDesk = cashDesk;
                return true;
            }
        }
        return false;
    }
}
