using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public ShopSpawner Spawner;
    public ShopPanel Panel;
    int HeroIndex = 0;
    void Start()
    {
        UpdateHero();
        Panel.OnSelectCliked += SelectHero;
        Panel.OnBuyCliked += BuyTheHero;
        Panel.SetCoinsCout(PlayerProgres.GetCoinsCount());
    }

    void Update()
    {
        
    }

    public void RightClick()
    {
        HeroIndex += 1;
        UpdateHero();
        SoundControler.Instance.PlaySound(SoundType.Click, true);
    }
    public void LeftClick()
    {
        HeroIndex -= 1;
        UpdateHero();
        SoundControler.Instance.PlaySound(SoundType.Click, true);
    }

    void UpdateHero()
    {
        for(int i = 0; i < Spawner.SpawnedHeros.Count; i ++)
        {
            Spawner.SpawnedHeros[i].SetActive(false);
        }
        if (HeroIndex < 0)
        {
            HeroIndex = Spawner.SpawnedHeros.Count - 1;
        }
        if (HeroIndex > Spawner.SpawnedHeros.Count - 1)
        {
            HeroIndex = 0;
        }
        Spawner.SpawnedHeros[HeroIndex].SetActive(true);
        Panel.SetHero(Spawner.SpawnedHerosParametres[HeroIndex]);
        UpdateButtons();
    }

    void SelectHero()
    {
        string HeroName = Spawner.SpawnedHerosParametres[HeroIndex].Name;
        PlayerProgres.SaveSelectedHero(HeroName);
        UpdateButtons();
        SoundControler.Instance.PlaySound(SoundType.Click, true);
    }

    void BuyTheHero()
    {
        int Cost = Spawner.SpawnedHerosParametres[HeroIndex].Cost;
        if (Cost <= PlayerProgres.GetCoinsCount())
        {
            SoundControler.Instance.PlaySound(SoundType.Buy, true);
            string HeroName = Spawner.SpawnedHerosParametres[HeroIndex].Name;
            PlayerProgres.BuyHero(HeroName);
            UpdateButtons();
            PlayerProgres.DecreaseCoins(Cost);
            Panel.SetCoinsCout(PlayerProgres.GetCoinsCount());
        }
    }
    void UpdateButtons()
    {
        string HeroName = Spawner.SpawnedHerosParametres[HeroIndex].Name;
        if(PlayerProgres.HeroWasBought(HeroName) == true)
        {
            Panel.ShowBuyButton(false);
            Panel.ShowSelectButton(true);
        }
        else
        {
            Panel.ShowBuyButton(true);
            Panel.ShowSelectButton(false);
        }
        if(HeroName == PlayerProgres.GetSelectedHero())
        {
            Panel.HeroWasSelected(true);
        }
        else
        {
            Panel.HeroWasSelected(false);
        }
        Panel.SetBuyPrice(Spawner.SpawnedHerosParametres[HeroIndex].Cost);
    }

    [ContextMenu("AddCoins")]
    public void AddCoins()
    {
        PlayerProgres.AddCoins(200);
    }

}
