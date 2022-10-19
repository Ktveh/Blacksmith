using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private Vector3 _startRotation;

    public Sprite Icon => _icon;

    public void Align()
    {
        transform.localEulerAngles = _startRotation;
    }
}
