using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class HelpTrigger : Trigger
{
    [SerializeField] private Image _helpWindow;
    [SerializeField] private TextMeshProUGUI _helpTMPro;
    [SerializeField] private string _text;
    [SerializeField] private bool _isLast;

    private const float MaxImageScale = 5;
    private const float MinImageScale = 0;
    private const float DurationChangeImage = 0.3f;

    private void Awake()
    {
        _helpWindow.gameObject.transform.DOScaleX(MinImageScale, DurationChangeImage);
        _helpWindow.gameObject.transform.DOScaleX(MaxImageScale, DurationChangeImage).SetDelay(DurationChangeImage);
        _helpTMPro.text = _text;
    }

    protected override void Active()
    {
        if (_isLast)
        {
            _helpWindow.gameObject.transform.DOScaleX(MinImageScale, DurationChangeImage);
        }
        base.Active();
    }
}
