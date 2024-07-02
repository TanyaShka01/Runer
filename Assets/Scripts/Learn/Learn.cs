using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learn : MonoBehaviour
{
    
    void Start()
    {
        Dictionary<string, int> Lights = new Dictionary<string, int>();
        Lights.Add("Red", 50);
        Lights.Add("Yellow", 3);
        Lights.Add("Green", 20);
        Debug.Log(Lights["Yellow1"]);
    }

    void Update()
    {
        
    }

    void MadifyVector(int NumberToMadify)
    {
        NumberToMadify = 57;
    }
}
