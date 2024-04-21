using System.Collections;
using UnityEngine;


public class UsualHeroCollision : BaseHeroCollision
{
    Hero hero;
    public void Awake()
    {
        hero = GetComponent<Hero>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (IsWorking == false)
        { 
            return; 
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            hero.StopRun();
        }
    }
}
