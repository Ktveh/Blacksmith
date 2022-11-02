using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class Language : MonoBehaviour
{
    private const float WaitTime = 0.25f;
    private const string EnglishCode = "en";
    private const string RussianCode = "ru";
    private const string TurkishCode = "tr";
    private const string EnglishLanguage = "English";
    private const string RussianLanguage = "Russian";
    private const string TurkishLanguage = "Turkish";

#if UNITY_WEBGL && !UNITY_EDITOR
    private IEnumerator Start()
    {
        while (YandexGamesSdk.IsInitialized)
        {
            yield return new WaitForSeconds(WaitTime);
            if (YandexGamesSdk.IsInitialized)
            {
                ChangeLanguage();
            }
        }
    }
#endif

    private void ChangeLanguage()
    {
        string languageCode = YandexGamesSdk.Environment.i18n.lang;
        string language;
        switch (languageCode)
        {
            case EnglishCode:
                language = EnglishLanguage;
                break;
            case RussianCode:
                language = RussianLanguage;
                break;
            case TurkishCode:
                language = TurkishLanguage;
                break;
            default:
                language = EnglishLanguage;
                break;
        }

        Lean.Localization.LeanLocalization.SetCurrentLanguageAll(language);
    }
}
