using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class Trigger : MonoBehaviour
{
    [SerializeField] private Trigger _nextTrigger;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private string _helpText;
    [SerializeField] private bool _isWriteText;
    [SerializeField] private bool _isRotate;
    [SerializeField] private Vector3 _rotate;
    [SerializeField] private bool _isFloat;
    [SerializeField] private float _distanceFloat;
    [SerializeField] private float _speedFloat;

    private const float MaxImageScale = 5;
    private const float MinImageScale = 0;
    private const float DurationChangeImage = 0.3f;

    private void Awake()
    {
        if (_isWriteText)
        {
            _image.gameObject.transform.DOScaleX(MaxImageScale, DurationChangeImage);
            _text.text = _helpText;
        }
    }

    private void Start()
    {
        if (_isFloat)
            transform.DOMoveY(transform.position.y + _distanceFloat, _speedFloat).SetLoops(-1, LoopType.Yoyo).SetSpeedBased(true);
    }

    private void Update()
    {
        if (_isRotate)
            transform.Rotate(_rotate);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _image.gameObject.transform.DOScaleX(MinImageScale, DurationChangeImage);
            _nextTrigger.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public Transform GetNextTriggerTransform()
    {
        return _nextTrigger.transform;
    }
}
