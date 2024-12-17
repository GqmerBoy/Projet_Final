using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;

    [SerializeField] public GameObject startScript;

    public bool menuActive = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void TogglePauseMenu(){
        if(startScript.GetComponent<StartMenu>().startMenuActive == true){
            return;
        }

        else
        {
            if(pauseMenu.activeInHierarchy == false){
                pauseMenu.SetActive(true);
                menuActive = true;
                Time.timeScale = 0;
            }

            else{
                pauseMenu.SetActive(false);
                menuActive = false;
                Time.timeScale = 1;
            }  
        }

        
    }
}
