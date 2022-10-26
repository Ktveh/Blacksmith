using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Converter : MonoBehaviour
{
    [SerializeField] private List<Item> _inputItems;
    [SerializeField] private List<Item> _outputItems;

    public virtual Item Convert(Item currentItem)
    {
        Item newItem;
        for (int i = 0; i < _inputItems.Count; i++)
        {
            if (_inputItems[i].GetType() == currentItem.GetType())
            {
                newItem = Instantiate(_outputItems[i], currentItem.transform.position, currentItem.transform.rotation);
                newItem.Align();
                Destroy(currentItem.gameObject);
                return newItem;
            }
        }
        return currentItem;
    }
}
