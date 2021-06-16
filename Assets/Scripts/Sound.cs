using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string Name;
    public AudioClip Clip;
    [Range(0.0f, 1.0f)] public float Volume;
    [Range(0.1f, 3.0f)] public float Pitch;
    public bool ToLoop;
    public bool IsMusic;
    [HideInInspector] public AudioSource Source;
}
