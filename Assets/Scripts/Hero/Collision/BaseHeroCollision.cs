using System.Collections;
using UnityEngine;


public class BaseHeroCollision : MonoBehaviour
{
    protected bool IsWorking;
    void OnDisable()
    {
        IsWorking = false;
    }

    void OnEnable()
    {
        IsWorking = true;
    }
}