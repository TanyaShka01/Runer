using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoesAbility : BaseAbility
{
    GameObject Hero;
    protected override async void Activate(GameObject hero)
    {
        base.Activate(hero);
        Duration = 5;
        Hero = hero;
        hero.GetComponent<Hero>().ActivateShoesAbility(true);
        await UniTask.WaitForSeconds(Duration);
        if (work == true)
        {
            hero.GetComponent<Hero>().ActivateShoesAbility(false);
        }
    }

    public override void Stop()
    {
        base.Stop();
        Hero.GetComponent<Hero>().ActivateShoesAbility(false);
    }
}
