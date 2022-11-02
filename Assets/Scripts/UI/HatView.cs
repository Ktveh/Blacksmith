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

    private Hat _hat;
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

    public void Render(Hat hat)
    {
        _hat = hat;
        _icon.sprite = hat.Icon;
        _name.text = Lean.Localization.LeanLocalization.GetTranslationText(hat.Name);
    }

    private void OnButtonClick()
    {
        _hatsHanger.SelectHat(_hat.Name);
    }
}
