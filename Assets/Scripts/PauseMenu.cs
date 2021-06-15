using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private Sound currentMusic;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        currentMusic.Source.UnPause();
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        currentMusic = FindObjectOfType<AudioManager>().Sounds.First(sound => sound.Source.isPlaying && sound.IsMusic);
        currentMusic.Source.Pause();
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        FindObjectOfType<AudioManager>().PlayMusic("MainMenuTheme");
        SceneManager.LoadScene(0);
    }
    
    public void Exit()
    {
        Debug.Log("EXIT!");
        Application.Quit(); 
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }
}
