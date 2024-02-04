using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllHerosSettings", menuName = "Settings/AllHerosSettings")]
public class AllHerosSettings : ScriptableObject
{
    public HeroParametres[] AllHeros;
}

[Serializable]
public class HeroParametres
{
    public string Name;
    public GameObject MenuPrefab;
    public GameObject GamePlayPrefab;
    public int Cost;
}
