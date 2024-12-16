using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] public Canvas pauseMenu;

    public bool menuActive = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.enabled = false;
    }

    public void TogglePauseMenu(){
        pauseMenu.enabled =! pauseMenu.enabled;
        menuActive =! menuActive;
        PauseMenu();
    }

    public void PauseMenu(){
        if(menuActive == false){
            Time.timeScale = 1;
        }

        else{
            Time.timeScale = 0;
        }
    }
}
