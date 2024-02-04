using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public static class PlayerProgres 
{
    public static void SaveRecord(int Record)
    {
        if (Record > GetRecord())
        {
            PlayerPrefs.SetInt("RecordKey", Record);
        }
    }

    public static int GetRecord()
    {
        return PlayerPrefs.GetInt("RecordKey");
    }

    public static void SaveSelectedHero(string HeroName)
    {
        PlayerPrefs.SetString("SelectedHero", HeroName);
    }

    public static string GetSelectedHero()
    {
        return PlayerPrefs.GetString("SelectedHero");
    }

    public static void BuyHero(string HeroName)
    {
        PlayerPrefs.SetInt(HeroName, 1);
    }

    public static bool HeroWasBought(string HeroName)
    {
        if (PlayerPrefs.GetInt(HeroName) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static int GetCoinsCount()
    {
        return PlayerPrefs.GetInt("Coin");
    }
    public static void AddCoins(int CoinsAdd)
    {
        PlayerPrefs.SetInt("Coin", GetCoinsCount() + CoinsAdd);
    }

    public static void DecreaseCoins(int CoinsMinus)
    {
        PlayerPrefs.SetInt("Coin", GetCoinsCount() - CoinsMinus);
    }
}
