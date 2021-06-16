using UnityEngine.Audio;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using System;

public class AudioManager : MonoBehaviour
{
    public List<Sound> Sounds;
    public static AudioManager instance;

    public void PlaySound(string name)
    {
        var sound = Sounds.Find(sound => sound.Name == name);
        if (sound == null)
            throw new ArgumentException("Couldn't find the sound: " + name);
        sound.Source.Play();
    }

    public void PlayMusic(string name)
    {
        Sounds.Where(sound => sound.Source.isPlaying && sound.IsMusic).ToList().ForEach(sound => sound.Source.Stop());
        PlaySound(name);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (var sound in Sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;
            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
            sound.Source.loop = sound.ToLoop;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
