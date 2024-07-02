using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour
{
    public GameObject LosePanel;
    public GameObject PausePanel;
    public GameObject Timer;
    public Image Filling;
    public TMP_Text Result;

    public void ShowLosePanel(int Score)
    {
        int Record = PlayerProgres.GetRecord();
        if (Score > Record)
        {
            Result.text = $"{LocalizationService.Instance.Translate("NewScoreKey")}  {Record}";
        }
        else
        {
            Result.text = $"{LocalizationService.Instance.Translate("BestScoreKey")}: {Score}\n {LocalizationService.Instance.Translate("YourScoreKey")}: {Record}";
        }
        LosePanel.SetActive(true);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MakePause()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }
    public void Continue()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }
    public void OpenMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void ChangeAbilityTime(float filling)
    {
        Filling.fillAmount = filling;
    }

    public void ActivetAbilityTimer(bool IsAcrive)
    {
        Timer.SetActive(IsAcrive);
    }
}
