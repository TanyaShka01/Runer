using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int AddCoins;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

     void OnTriggerEnter(Collider Col) 
    {
        if(Col.gameObject.tag == "Player")
        {
            PlayerProgres.AddCoins(AddCoins);
            Destroy(gameObject);
        }    
    }
}
