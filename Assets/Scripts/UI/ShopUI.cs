using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopUI : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void BackMenu()
    {
        SoundControler.Instance.PlaySound(SoundType.Click, true);
        SceneManager.LoadScene("Menu");
    }
}
