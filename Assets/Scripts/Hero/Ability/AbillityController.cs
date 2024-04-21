using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class AbillityController : MonoBehaviour
{
    public GamePlayUI gamePlayUI;
    float StartTime;
    float AbilityFill;
    List<BaseAbility> AllAbilitys;
    BaseAbility WorkAbility;
    void Start()
    {
        AllAbilitys = new List<BaseAbility>();
    }

    void Update()
    {
        if (WorkAbility != null && AbilityFill >= 0)
        {
            gamePlayUI.ActivetAbilityTimer(true);
            float x = StartTime + WorkAbility.Duration;
            float y = x - Time.time; 
            AbilityFill = y / WorkAbility.Duration;
            gamePlayUI.ChangeAbilityTime(AbilityFill);
        }
        else
        {
            gamePlayUI.ActivetAbilityTimer(false);
        }
    }

    public void AddAbility(BaseAbility SpawndAbility)
    {
        AllAbilitys.Add(SpawndAbility);
        SpawndAbility.OnCollected += AbilityCollected;
    }

    void AbilityCollected(BaseAbility CollectedAbility)
    {
        AbilityFill = 1;
        StartTime = Time.time;
        if (WorkAbility != null)
        {
            WorkAbility.Stop();
        }
        WorkAbility = CollectedAbility;
        WorkAbility.OnStoped += AbilityStop;
    }

    void AbilityStop()
    { 
        WorkAbility = null;
    }
}
