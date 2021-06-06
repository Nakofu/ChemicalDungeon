using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    void Update()
    {
       
    }
    
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    
}
