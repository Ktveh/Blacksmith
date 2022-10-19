using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Container : MonoBehaviour
{
    [SerializeField] private Vector3 _amount;
    [SerializeField] private Vector3 _indent;
    [SerializeField] private int _limit;

    [SerializeField] protected float Delay;
    [SerializeField] protected List<Item> NeededItems;
    [SerializeField] protected List<Container> Donors;
    [SerializeField] protected Transform FirstElementPosition;
    [SerializeField] protected List<Item> Items;

    protected float EllapsedTime = 0;

    public event UnityAction<Dictionary<Item, int>> ItemsChanged;

    public int Limit => _limit;
    public bool IsEmpty => Items.Count <= 0;
    public bool IsFull => Items.Count == _limit;

    private void Start()
    {
        PlaceItems();
        ReportChange();
    }

    private void OnTriggerStay(Collider other)
    {
        EllapsedTime += Time.deltaTime;

        Container container;
        if (EllapsedTime > Delay && other.TryGetComponent<Container>(out container))
        {
            CheckDonors(container);
            EllapsedTime = 0;
        }
    } 

    public void LimitUpgrade(int increase)
    {
        _limit += increase;
    }

    public void DelayUpgrade(float decrease)
    {
        Delay -= decrease;
    }

    protected virtual void CheckDonors(Container container)
    {
        foreach (Container donor in Donors)
        {
            if (container.gameObject == donor.gameObject)
            {
                Take(container);
            }
        }
    }

    public virtual void Take(Container donor)
    {
        if (!donor.IsEmpty && Items.Count < _limit)
        {
            foreach(Item neededItem in NeededItems)
            {
                Item takedItem = donor.Give(neededItem);
                if (takedItem != null)
                {
                    Items.Add(takedItem);
                    Sort();
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
                Sort();
                PlaceItems();
                ReportChange();
                return foundItem;
            }
        }
        return null;
    }

    protected virtual void Sort()
    {
        List<Item> sortListItems = new List<Item>();
        foreach (Item neededItem in NeededItems)
        {
            foreach (Item item in Items)
            {
                if (neededItem.GetType() == item.GetType())
                {
                    sortListItems.Add(item);
                }
            }
        }
        Items = sortListItems;
    }

    protected virtual void PlaceItems()
    {
        int index = 0;
        for (int y = 0; y < _amount.y; y++)
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
                        Items[index].Align();
                        index++;
                    }
                }
            }
        }
    }

    protected void ReportChange()
    {
        Dictionary<Item, int> amountItems = new Dictionary<Item, int>();
        foreach (Item neededItem in NeededItems)
        {
            amountItems[neededItem] = 0;
            foreach (Item item in Items)
            {
                if (neededItem.GetType() == item.GetType())
                {
                    amountItems[neededItem]++;
                }
            }
        }
        ItemsChanged?.Invoke(amountItems);
    }
}
