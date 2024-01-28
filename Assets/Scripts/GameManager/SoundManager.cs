using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource BGMSource,SFXSource;
    public Sound[] BGMSounds, SFXSounds;
    
    //public float BGMVolume;
    //public float SFXVolume;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad((gameObject));
        }
        else
        {
            Destroy(gameObject);
            
        }
    }

    public void ToggleBGM()
    {
        BGMSource.mute = !BGMSource.mute;
        
    }
    
    public void ToggleSFX()
    {
        SFXSource.mute = !SFXSource.mute;
        
    }

    
    // public void MusicVolume()
    // {
    //     SoundManager.instance.MusicVolume();
    // }
    
    
    public void PlayBGM(string name)
    {
        Sound s = Array.Find(BGMSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("无法找到声音");
        }
        else
        {
            BGMSource.clip = s.clip;
            BGMSource.Play();
        }
    }
    
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(SFXSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("无法找到声音");
        }
        else
        {
            SFXSource.clip = s.clip;
            SFXSource.Play();
        }
    }
}
