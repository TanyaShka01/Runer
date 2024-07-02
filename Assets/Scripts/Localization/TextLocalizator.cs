using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextLocalizator : MonoBehaviour
{
    public string WordKey;
    void Start()
    {
        LocalizationService.Instance.OnLanguageChanged += LocallastText;
        LocallastText();
    }

    void LocallastText()
    {
        TMP_Text Text = GetComponent<TMP_Text>();
        Text.text = LocalizationService.Instance.Translate(WordKey);
    }

    private void OnDestroy()
    {
        LocalizationService.Instance.OnLanguageChanged -= LocallastText;
    }
}
