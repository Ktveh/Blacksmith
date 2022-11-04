using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private Sprite _soundOn;
    [SerializeField] private Sprite _soundOff;
    [SerializeField] private Button _soundButton;
    [SerializeField] private AudioListener _soundListener;

    private static bool _isOn;

    private void OnEnable()
    {
        _soundButton.onClick.AddListener(OnButtonClick);
        CheckButtonSprite();
    }

    private void OnDisable()
    {
        _soundButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (_isOn)
        {
            if (focus)
            {
                AudioListener.volume = 1;
            }
            else
            {
                AudioListener.volume = 0;
            }
        }
    }

    private void OnButtonClick()
    {
        if (_isOn)
        {
            _isOn = false;
            AudioListener.volume = 0;  
        }
        else
        {
            _isOn = true;
            AudioListener.volume = 1;
        }

        CheckButtonSprite();
    }

    private void CheckButtonSprite()
    {
        if (_isOn)
        {
            _soundButton.image.sprite = _soundOn;
        }
        else
        {
            _soundButton.image.sprite = _soundOff;
        }
    }
}
