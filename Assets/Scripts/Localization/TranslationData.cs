using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class LocalizationData
{
    public List<LanguageData> Langs;
}

[Serializable]
public class LanguageData
{
    public string Lang;
    public List<WordTranslation> Translations;
}

[Serializable]
public class WordTranslation
{
    public string TranslationKey;
    public string Translation;
}
