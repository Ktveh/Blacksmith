using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Container : MonoBehaviour
{
    [SerializeField] private Vector3 _amount;
    [SerializeField] private Vector3 _indent;
    [SerializeField] private List<Container> _donors;
    [SerializeField] private List<Item> _neededItems;
    [SerializeField] private int _limit;
    [SerializeField] private float _delay;

    [SerializeField] protected List<Item> Items;
    [SerializeField] protected Transform FirstElementPosition;

    private float _ellapsedTime = 0;

    public event UnityAction<Dictionary<Item, int>> ItemsChanged;

    public bool IsEmpty => Items.Count == 0;

    private void Start()
    {
        PlaceItems();
        ReportChange();
    }

    private void OnTriggerStay(Collider other)
    {
        _ellapsedTime += Time.deltaTime;

        Container container;
        if (_ellapsedTime > _delay && other.TryGetComponent<Container>(out container))
        {
            foreach (Container donor in _donors)
            {
                if (container.gameObject == donor.gameObject)
                {
                    Take(container);
                }
            }
            _ellapsedTime = 0;
        }
    }

    private void PlaceItems()
    {
        int index = 0;
        for(int y = 0; y < _amount.y; y++)
        {
            for (int x = 0; x < _amount.x; x++)
            {
                for (int z = 0; z < _amount.z; z++)
                {
                    if (index < Items.Count)
                    {
                        Items[index].transform.position = new Vector3(FirstElementPosition.position.x + _indent.x * x, 
                            FirstElementPosition.position.y + _indent.y * y, FirstElementPosition.position.z + _indent.z * z);
                        Items[index].transform.SetParent(FirstElementPosition);
                        Items[index].transform.rotation = new Quaternion(0, 0, 0, 0);
                        index++;
                    }
                }
            }
        } 
    }

    private void ReportChange()
    {
        Dictionary<Item, int> amountItems = new Dictionary<Item, int>();
        foreach (Item neededItem in _neededItems)
        {
            amountItems[neededItem] = 0;
            foreach (Item item in Items)
            {
                if (neededItem.GetType() == item.GetType())
                {
                    amountItems[neededItem]++;
                    Debug.Log(amountItems[neededItem].ToString());
                }
            }
        }
        ItemsChanged?.Invoke(amountItems);
    }

    public virtual void Take(Container donor)
    {
        if (!donor.IsEmpty && Items.Count < _limit)
        {
            foreach(Item neededItem in _neededItems)
            {
                Item takedItem = donor.Give(neededItem);
                if (takedItem != null)
                {
                    Items.Add(takedItem);
                    PlaceItems();
                    ReportChange();
                    return;
                }
            }
        }
    }

    public virtual Item Give(Item neededItem)
    {
        for (int i = Items.Count - 1; i >= 0; i--)
        {
            if (Items[i].GetType() == neededItem.GetType())
            {
                Item foundItem = Items[i];
                Items.RemoveAt(i);
                PlaceItems();
                ReportChange();
                return foundItem;
            }
        }
        return null;
    }
}
