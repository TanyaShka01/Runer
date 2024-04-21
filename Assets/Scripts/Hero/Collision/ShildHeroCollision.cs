using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShildHeroCollision : BaseHeroCollision
{
    Hero hero;
    public ParticleSystem Clouds;
    public ParticleSystem SphereAffect;
    public GameObject Sphere;
    public ParticleSystem Booble;
    public void Awake()
    {
        hero = GetComponent<Hero>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Obstacle")
        {
            return;
        }
        if (IsWorking == false)
        {
            return;
        }
        Work(collision);

    }

    private async void Work(Collision collision)
    {
        Clouds.Play();
        Clouds.transform.position = collision.contacts[0].point;
        GameObject Obstacle = collision.gameObject;
        Destroy(collision.gameObject);
        while (Obstacle != null)
        {
            await UniTask.Yield();
        }
        hero.ShildDisableForce();
    }

    void OnDisable()
    {
        Sphere.SetActive(false);
        IsWorking = false;
        SphereAffect.Stop();
        Booble.Play();
    }

    void OnEnable()
    {
        Sphere.SetActive(true);
        SphereAffect.Play();
        IsWorking = true;
    }
}
