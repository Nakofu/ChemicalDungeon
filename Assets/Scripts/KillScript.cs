using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class KillScript : MonoBehaviour
{
    public GameObject DeathMenuUI;
    private Sound currentMusic;
    
    public void LoadLevel(int index)
    {
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
        FindObjectOfType<AudioManager>().PlayMusic("GameTheme" + new System.Random().Next(1, 4));
        SceneManager.LoadScene(index);
    }
    
    public void Exit()
    {
        Debug.Log("EXIT!");
        Application.Quit(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Player>().health <= 0)
        {
            Time.timeScale = 0f;
            PauseMenu.GameIsPaused = true;
            currentMusic = FindObjectOfType<AudioManager>().Sounds.First(sound => sound.Source.isPlaying && sound.IsMusic);
            DeathMenuUI.SetActive(true);
        }
    }
}
