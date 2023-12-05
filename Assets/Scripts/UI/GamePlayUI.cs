using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUI : MonoBehaviour
{
    public GameObject LosePanel;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ShowLosePanel()
    {
        LosePanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
