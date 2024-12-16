using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] public Canvas startMenu;

    [SerializeField] public GameObject scriptTimer;

    // Start is called before the first frame update
    void Start()
    {
        startMenu.enabled = true;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        scriptTimer.GetComponent<Timer>()._currentTime = 0;
        startMenu.enabled = false;
        Time.timeScale = 1;
    }
}
