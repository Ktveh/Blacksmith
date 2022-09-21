using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Container : MonoBehaviour
{
    [SerializeField] private int _countX;
    [SerializeField] private int _countY;
    [SerializeField] private int _countZ;
    [SerializeField] private float _distanceX;
    [SerializeField] private float _distanceY;
    [SerializeField] private float _distanceZ;
    [SerializeField] private bool _isDonor;
    [SerializeField] private int _limit;

    [SerializeField] protected List<Cargo> Cargos;
    [SerializeField] protected Transform FirstElementPosition;

    public event UnityAction<int> CargoChanged;

    public bool IsEmpty => Cargos.Count == 0;
    public bool IsDonor => _isDonor;

    private void Start()
    {
        Place();
    }

    protected void Place()
    {
        int index = 0;
        for(int i = 0; i < _countX; i++)
        {
            for (int j = 0; j < _countY; j++)
            {
                for (int k = 0; k < _countZ; k++)
                {
                    if (index < Cargos.Count)
                    {
                        Cargos[index].transform.position = new Vector3(FirstElementPosition.position.x + _distanceX * i, 
                            FirstElementPosition.position.y + _distanceY * j, FirstElementPosition.position.z + _distanceZ * k);
                        Cargos[index].transform.SetParent(FirstElementPosition);
                        Cargos[index].transform.rotation = new Quaternion(0, 0, 0, 0);
                        index++;
                    }
                }
            }
        }
    }

    public virtual Cargo Give()
    {
        int index = Cargos.Count - 1;
        Cargo lastCargo = Cargos[index];
        Cargos.RemoveAt(index);
        CargoChanged?.Invoke(Cargos.Count);
        return lastCargo;
    }

    public virtual void Take(Container donor)
    {
        if (!donor.IsEmpty && Cargos.Count < _limit)
        {
            Cargos.Add(donor.Give());
            CargoChanged?.Invoke(Cargos.Count);
            Place();
        }
    }
}
