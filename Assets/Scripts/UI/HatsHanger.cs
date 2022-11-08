using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatsHanger : MonoBehaviour
{
    [SerializeField] private List<Hat> _hats;
    [SerializeField] private Image _panel;
    [SerializeField] private Transform _content;
    [SerializeField] private HatView _template;
    [SerializeField] private Player _player;

    private List<bool> _unlockHats;

    private void Start()
    {
        _unlockHats = new List<bool>();
        foreach(Hat hat in _hats)
        {
            _unlockHats.Add(false);
        }
        LoadHats();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            ShowHats();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            HideHats();
        }
    }

    public void SelectHat(string hatName)
    {
        _player.ChangeHat(hatName);
        HideHats();
    }

    public void UnlockHat(Hat hat)
    {
        for(int i = 0; i < _hats.Count; i++)
        {
            if (_hats[i].Name == hat.Name)
            {
                _unlockHats[i] = true;
            }
        }
        SelectHat(hat.Name);
        SaveHats();
    }

    private void LoadHats()
    {
        string saveValue = PlayerPrefs.GetString(Save.Hat);
        if (saveValue == "")
        {
            _unlockHats[0] = true;
            return;
        }

        for(int i = 0; i < _unlockHats.Count; i++)
        {
            if (saveValue[i] == '1')
            {
                _unlockHats[i] = true;
            }
            else
            {
                _unlockHats[i] = false;
            }
        }
        _unlockHats[0] = true;
    }

    public void SaveHats()
    {
        string saveValue = "";
        for (int i = 0; i < _unlockHats.Count; i++)
        {
            if (_unlockHats[i])
            {
                saveValue += "1";
            }
            else
            {
                saveValue += "0";
            }
        }
        PlayerPrefs.SetString(Save.Hat, saveValue);
    }

    private void ShowHats()
    {
        _panel.gameObject.SetActive(true);
        for (int i = 0; i < _hats.Count; i++)
        {
            if (_unlockHats[i])
            {
                AddHat(_hats[i]);
            }
        }
    }

    private void HideHats()
    {
        foreach(Transform child in _content.transform)
        {
            Destroy(child.gameObject);
        }
        _panel.gameObject.SetActive(false);
    }

    private void AddHat(Hat hat)
    {
        var view = Instantiate(_template, _content.transform);
        view.Render(hat);
        view.SetHanget(this);
    }
}
