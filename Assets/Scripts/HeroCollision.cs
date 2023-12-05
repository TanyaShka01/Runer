using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeroCollision : MonoBehaviour
{
    public GamePlayUI UI;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            gameObject.GetComponent<Hero>().StopRun();
            UI.ShowLosePanel();
        }
    }
}
