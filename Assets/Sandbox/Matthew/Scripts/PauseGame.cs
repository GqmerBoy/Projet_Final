using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public bool activePauseMenu = true;
    // Start is called before the first frame update
    void Start()
    {
        DisplayPauseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DisplayPauseMenu(){
        
    }
}
