using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using System;

public class JerkAbility : BaseAbility
{
    GameObject Hero;

    
    protected override async void Activate(GameObject hero)
    {
        base.Activate(hero);
        Hero = hero;
        hero.GetComponent<Hero>().ActivateJerkAbility(true);
        await UniTask.WaitForSeconds(Duration);
        if (work == true)
        {
            hero.GetComponent<Hero>().ActivateJerkAbility(false);
        }
    }

    public override void Stop()
    {
        base.Stop();
        Hero.GetComponent<Hero>().ActivateJerkAbility(false);
    }
}
