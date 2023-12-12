using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScore : MonoBehaviour
{
    int StartPosition;
    void Start()
    {
        StartPosition = Convert.ToInt32(transform.position.z);
    }
    public int GetScore()
    {
        int Score = Convert.ToInt32(transform.position.z);
        int NewScore = Score - StartPosition;
        PlayerProgres.SaveRecord(NewScore);
        return NewScore;
    }
}
