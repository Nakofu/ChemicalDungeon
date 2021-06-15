using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().PlayMusic("LevelMenuTheme" + new System.Random().Next(1, 3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LoadLevel(int index)
    {
        FindObjectOfType<AudioManager>().PlayMusic("GameTheme" + new System.Random().Next(1, 4));
        SceneManager.LoadScene(index);
    }
}
