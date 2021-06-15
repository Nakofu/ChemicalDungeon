using UnityEngine.Audio;
using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<Sound> sounds;
    public static AudioManager instance;
    public void PlaySound(string name)
    {
        var sound = sounds.Find(sound => sound.Name == name);
        if (sound == null)
            throw new System.ArgumentException("Couldn't find the sound: " + name);
        sound.Source.Play();
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

        foreach (var sound in sounds)
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
