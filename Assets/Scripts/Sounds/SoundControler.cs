using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControler : MonoBehaviour
{
    public AudioSource Click;
    public AudioSource Buy;
    public static SoundControler Instance;
    public bool IsActive;

    Dictionary<SoundType, AudioSource> Sounds = new Dictionary<SoundType, AudioSource>();
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        IsActive = true;
        Sounds.Add(SoundType.Click, Click);
        Sounds.Add(SoundType.Buy, Buy);
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ActiwaitSound(bool Actiwe)
    {
        AudioSource[] AllAudioSources;
        AllAudioSources = GetComponentsInChildren<AudioSource>();
        for (int i = 0; i < AllAudioSources.Length; i += 1)
        {
            AllAudioSources[i].mute = !Actiwe;
        }
        IsActive = Actiwe;
    }

    

    public void PlaySound(SoundType AudioKey, bool Play)
    {
        if (Sounds.ContainsKey(AudioKey) == false)
        {
            Debug.LogWarning("No Key: " + AudioKey);
            return;
        }
        if (Play == true)
        {
            Sounds[AudioKey].Play();
        }
        else
        {
            Sounds[AudioKey].Stop();
        }
    }
}
