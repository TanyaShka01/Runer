using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUI : MonoBehaviour
{
    public GameObject LosePanel;
    public TMP_Text Result;

    public void ShowLosePanel(int Score)
    {
        int Record = PlayerProgres.GetRecord();
        if (Score > Record)
        {
            Result.text = $"New higt score!  {Record}";
        }
        else
        {
            Result.text = $"You Score: {Score}\n Your record: {Record}";
        }
        LosePanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
