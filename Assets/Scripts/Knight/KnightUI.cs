using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Knight))]
public class KnightUI : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Image _image; 

    private Knight _knight;

    private void Awake()
    {
        _knight = GetComponent<Knight>();
    }

    private void OnEnable()
    {
        _knight.SwordsChanged += ChangeSwordInfo;
    }

    private void OnDisable()
    {
        _knight.SwordsChanged -= ChangeSwordInfo;
    }

    private void ChangeSwordInfo(int count)
    {
        _image.fillAmount = (float)count / (float)_knight.NeedSwords;
        if (_image.fillAmount == 1)
            _canvas.gameObject.SetActive(false);
        else
            _canvas.gameObject.SetActive(true);
    }
}
