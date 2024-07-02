using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LangContextMenu : MonoBehaviour
{
    public Transform ContentList;
    public LangElement ListElementPref;
    public Button Lable;
    public GameObject LangScroll;
    public TMP_Text LableText;

    void Start()
    {
        List<LanguageData> AllLenguages = LocalizationService.Instance.GetAllLanguages();
        for (int i = 0; i < AllLenguages.Count; i++)
        {
            LangElement NewElement = Instantiate(ListElementPref, ContentList);
            NewElement.SetLang(AllLenguages[i].Lang);
            NewElement.OnClicked += SelectLanguage;
        }
        Lable.onClick.AddListener(ActivateLangList);
    }

    private void OnEnable()
    {
        LableText.text = LocalizationService.Instance.CurrentLang;
    }

    void SelectLanguage(string Language)
    {
        LangScroll.SetActive(false);
        Lable.gameObject.SetActive(true);
        LableText.text = Language;
        LocalizationService.Instance.SetLanguage(Language);
    }

    void ActivateLangList()
    {
        LangScroll.gameObject.SetActive(true);
        Lable.gameObject.SetActive(false);
    }
}
