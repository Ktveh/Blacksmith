using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Conveyor : Container
{
    [SerializeField] private float _speed;
    [SerializeField] private Converter _converter;
    [SerializeField] private Container _recipient;
    [SerializeField] private Transform _firstPosition;
    [SerializeField] private Transform _converterPosition;
    [SerializeField] private Transform _finishPosition;

    private List<Transform> _targets;

    private void Start()
    {
        _targets = new List<Transform>();
    }

    private void Update()
    {
        if (!IsEmpty)
        {
            CheckPosition();
        }
    }

    public override void Take(Container donor)
    {
        base.Take(donor);
        if (Items.Count > _targets.Count)
            _targets.Add(_firstPosition);
    }

    public override Item Give(Item neededItem)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].GetType() == neededItem.GetType())
            {
                Item foundItem = Items[i];
                Items.RemoveAt(i);
                _targets.RemoveAt(i);
                ReportChange();
                return foundItem;
            }
        }
        return null;
    }

    protected override void Sort()
    {
        return;
    }

    protected override void PlaceItems()
    {
        Items[Items.Count - 1].transform.SetParent(this.transform);
        Items[Items.Count - 1].transform.position = _firstPosition.position;
    }

    private void CheckPosition()
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (IsReachedPosition(Items[i], _firstPosition))
            {
                _targets[i] = _converterPosition;
            }
            if (IsReachedPosition(Items[i], _converterPosition))
            {
                _targets[i] = _finishPosition;
                Items[i] = _converter.Convert(Items[i]);
                Items[i].transform.SetParent(this.transform);
            }
            if (IsReachedPosition(Items[i], _finishPosition))
            {
                _recipient.Take(this);
                continue;
            }
            MoveItem(Items[i], _targets[i]);
        }
    }

    private bool IsReachedPosition(Item item, Transform neededPosition)
    {
        return item.transform.position == neededPosition.position;
    }
  
    private void MoveItem(Item item, Transform target)
    {
        item.transform.position = Vector3.MoveTowards(item.transform.position, target.position, _speed * Time.deltaTime);
    }
}
