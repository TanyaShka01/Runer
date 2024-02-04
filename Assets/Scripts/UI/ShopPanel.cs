using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    public Button SelectButton;
    public Button Buy;
    public TextMeshProUGUI HeroName;
    public TextMeshProUGUI WasSelectedText;
    public TextMeshProUGUI BuyPriceText;
    public TextMeshProUGUI CoinsCount;
    public GameObject SelectMark;
    public event Action OnSelectCliked;
    public event Action OnBuyCliked;
    void Start()
    {
        SelectButton.onClick.AddListener(SelectHero);
        Buy.onClick.AddListener(BuyHero);
    }

    public void SetHero(HeroParametres Hero)
    {
        HeroName.text = Hero.Name;
    }

    public void ShowBuyButton(bool Show)
    {
        Buy.gameObject.SetActive(Show);
    }
    public void ShowSelectButton(bool Show)
    {
        SelectButton.gameObject.SetActive(Show);
    }
    public void HeroWasSelected(bool Select)
    {
        if (Select)
        {
            WasSelectedText.text = "Selected";
            SelectButton.interactable = false;
            SelectMark.SetActive(true);
        }
        else
        {
            WasSelectedText.text = "Select";
            SelectButton.interactable = true;
            SelectMark.SetActive(false);
        }
    }
    
    public void SetCoinsCout(int Coins)
    {
        CoinsCount.text = Coins.ToString();
    }

    public void SetBuyPrice(int SetPrice)
    {
        BuyPriceText.text = "Buy: " + SetPrice.ToString();
    }

    void SelectHero()
    {
        OnSelectCliked.Invoke();
    }

    void BuyHero()
    {
        OnBuyCliked.Invoke();
    }

}
