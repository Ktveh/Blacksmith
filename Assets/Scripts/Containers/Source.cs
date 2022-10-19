using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : Container
{
    private void Update()
    {
        if (!IsFull)
        {
            Item newItem = Instantiate(NeededItems[0], transform.position, transform.rotation);
            Items.Add(newItem);
        }
    }
}
