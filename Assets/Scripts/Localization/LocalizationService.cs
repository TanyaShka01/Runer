using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;

public class LocalizationService : MonoBehaviour
{
    public TextAsset LocalizationData;
    public static LocalizationService Instance;
    public string CurrentLang;
    LocalizationData Data;
    public event Action OnLanguageChanged;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);

        string LocalizationJson = LocalizationData.text;
        Data = JsonUtility.FromJson<LocalizationData>(LocalizationJson);
        if (PlayerPrefs.HasKey("Lang") == true)
        {
            CurrentLang = PlayerPrefs.GetString("Lang");
        }
        else
        {
            CurrentLang = "RU";
        }
    }

    public void SetLanguage(string NewLang)
    {
        CurrentLang = NewLang;
        PlayerPrefs.SetString("Lang", CurrentLang);
        OnLanguageChanged.Invoke();
    }

    public List<LanguageData> GetAllLanguages()
    {
        return Data.Langs;
    }

    public string Translate(string WordKey)
    {
        LanguageData Language = Data.Langs.FirstOrDefault(Language => Language.Lang == CurrentLang);
        WordTranslation Word = Language.Translations.FirstOrDefault(translation => translation.TranslationKey == WordKey);
        if (Word == null)
        {
            Debug.LogWarning("Не найдено такое слово: " + WordKey);
            return "";
        }
        string result = Word.Translation;
        return result;
    }

}
