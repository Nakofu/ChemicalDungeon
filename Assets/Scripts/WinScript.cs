using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
public class WinScript : MonoBehaviour
{
    
    public GameObject WinMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
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
}
