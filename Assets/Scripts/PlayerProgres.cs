using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public static class PlayerProgres 
{
    public static void SaveRecord(int Record)
    {
        if (Record > GetRecord())
        {
            PlayerPrefs.SetInt("RecordKey", Record);
        }
    }

    public static int GetRecord()
    {
        return PlayerPrefs.GetInt("RecordKey");
    }
}
