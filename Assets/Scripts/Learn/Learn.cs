using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learn : MonoBehaviour
{
    public Rigidbody Body1;
    public Rigidbody Body2;
    void Start()
    {
        Body1.mass = 48;
        Body2.mass = 83;
    }

    void Update()
    {
        
    }

    void MadifyVector(int NumberToMadify)
    {
        NumberToMadify = 57;
    }
}
