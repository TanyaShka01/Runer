using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JerkHeroCollision : BaseHeroCollision
{
    public ParticleSystem Clouds;
    public ParticleSystem FireTrail;

    private void OnCollisionEnter(Collision collision)
    {
        if (IsWorking == false)
        {
            return;
        }
        if (collision.gameObject.tag == "Obstacle")
        {

            Clouds.Play();
            Clouds.transform.position = collision.contacts[0].point;
            Destroy(collision.gameObject);
        }
    }
    void OnDisable()
    {
        FireTrail.Stop();
        IsWorking = false;
    }

    void OnEnable()
    {
        FireTrail.Play();
        IsWorking = true;
    }
}
