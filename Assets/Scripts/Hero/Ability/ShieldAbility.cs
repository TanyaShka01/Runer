using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAbility : BaseAbility
{
    GameObject Hero;
    protected override async void Activate(GameObject hero)
    {
        base.Activate(hero);
        Hero = hero;
        hero.GetComponent<Hero>().ActivateShildAbility(true, this);
        await UniTask.WaitForSeconds(Duration);
        if (work == true)
        {
            hero.GetComponent<Hero>().ActivateShildAbility(false);
        }
    }

    public override void Stop()
    {
        base.Stop();
        Hero.GetComponent<Hero>().ActivateShildAbility(false);
    }
}
