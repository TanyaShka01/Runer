using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public MenuSettings SettingsWindow;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        SoundControler.Instance.PlaySound(SoundType.Click, true);
        SceneManager.LoadScene("Game");
    }
    public void OpenShop()
    {
        SoundControler.Instance.PlaySound(SoundType.Click, true);
        SceneManager.LoadScene("Shop");
    }

    public void OpenSettings() 
    {
        SoundControler.Instance.PlaySound(SoundType.Click, true);
        SettingsWindow.Open();
    }
}
