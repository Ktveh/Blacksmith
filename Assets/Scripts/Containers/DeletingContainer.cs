using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletingContainer : Container
{
    protected override void PlaceItems()
    {
        base.PlaceItems();
        Items.Clear();
        foreach (Transform child in FirstElementPosition)
        {
            Destroy(child.gameObject);
        }
    }
}
