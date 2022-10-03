using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private Sprite _icon;

    public Sprite Icon => _icon;
}
