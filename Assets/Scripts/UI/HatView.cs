using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HatView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Button _button;

    private HatsHanger _hatsHanger;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public void SetHanget(HatsHanger hanger)
    {
        _hatsHanger = hanger;
    }

    public void Render(Hat hat, HatsHanger hanger)
    {
        _hatsHanger = hanger;
        _icon.sprite = hat.Icon;
        _name.text = hat.Name;
    }

    private void OnButtonClick()
    {
        _hatsHanger.SelectHat(_name.text);
    }
}
