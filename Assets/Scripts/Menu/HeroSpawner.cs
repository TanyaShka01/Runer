using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core;
using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
    public AllHerosSettings Heros;
    HeroParametres Hero1;
    void Start()
    {
        Hero1 = Heros.AllHeros[0];
        Debug.Log(Hero1.Name);
        GameObject Hero = Instantiate(Hero1.MenuPrefab);
        Hero.transform.position = new Vector3(0, -0.5f, 0);
        Hero.transform.eulerAngles = new Vector3(0, 160, 0);
    }

    void Update()
    {
        
    }
}
