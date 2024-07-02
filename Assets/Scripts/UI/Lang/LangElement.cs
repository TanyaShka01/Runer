using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class LangElement : MonoBehaviour, IPointerClickHandler
{
    public string LanguageKey;
    public TMP_Text LanguageName;

    public event Action<string> OnClicked;

    public void OnPointerClick(PointerEventData Data)
    {
        OnClicked.Invoke(LanguageKey);
    }

    public void SetLang(string LangKey)
    {
        LanguageKey = LangKey;
        LanguageName.text = LangKey;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
