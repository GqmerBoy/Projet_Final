using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public bool activePauseMenu = false;
    // Start is called before the first frame update
    void Start()
    {
        TogglePauseMenu();
    }

    public void TogglePauseMenu(){
        if(activePauseMenu){
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }

        else if(!activePauseMenu){
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
