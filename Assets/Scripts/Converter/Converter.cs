using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Converter : MonoBehaviour
{
    [SerializeField] private Item _inputItem;
    [SerializeField] private Item _outputItem;

    public virtual Item Convert(Item currentItem)
    {
        Item newItem = Instantiate(_outputItem, currentItem.transform.position, currentItem.transform.rotation);
        newItem.Align();
        Destroy(currentItem.gameObject);
        return newItem;
    }
}
