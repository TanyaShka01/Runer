using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    public Toggle SoundToggle;
    public Button Exit;
    public Slider DifficultySlider;

    void Start()
    {
        SoundToggle.OnSwitch += SwitchSound;
        Exit.onClick.AddListener(Exited);
        DifficultySlider.onValueChanged.AddListener(ChangeDifficulty);
    }


    public void Open()
    {
        gameObject.SetActive(true);
        SoundToggle.SwitchState(SoundControler.Instance.IsActive);
        DifficultySlider.value = PlayerProgres.GetDifficulty();
    }

    void SwitchSound(bool SoundOn)
    {
        SoundControler.Instance.PlaySound(SoundType.Click, true);
        SoundControler.Instance.ActiwaitSound(SoundOn);
    }

    void Exited()
    {
        SoundControler.Instance.PlaySound(SoundType.Click, true);
        gameObject.SetActive(false);
    }

    void ChangeDifficulty(float Difficulty)
    {
        PlayerProgres.SetDifficulty(Difficulty);
    }

}
