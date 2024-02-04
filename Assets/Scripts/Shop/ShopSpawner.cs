using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UIElements;

public class ShopSpawner : MonoBehaviour
{
    public AllHerosSettings AllHeroSettings;
    public List<GameObject> SpawnedHeros;
    public List<HeroParametres> SpawnedHerosParametres; 
    void Awake()
    {
        for (int i = 0; i < AllHeroSettings.AllHeros.Length; i ++)
        {
            HeroParametres Hero = AllHeroSettings.AllHeros[i];
            GameObject SpawnHero = Instantiate(Hero.MenuPrefab);
            SpawnedHeros.Add(SpawnHero);
            SpawnedHerosParametres.Add(Hero);
            SpawnHero.transform.position = new Vector3(-1.47f, 0.06f, -6.91f);
            SpawnHero.transform.eulerAngles = new Vector3(0, 168.79f, 0);
        }
    }

    void Update()
    {
        
    }
}
