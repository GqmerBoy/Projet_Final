using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] public GameObject startMenu;
    [SerializeField] public Canvas timer;
    [SerializeField] public GameObject scriptTimer;

    public bool startMenuActive = true;

    // Start is called before the first frame update
    void Start()
    {
        timer.enabled = false;
        startMenu.SetActive(true);
        Time.timeScale = 0;
        startMenuActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        scriptTimer.GetComponent<Timer>()._currentTime = 0;
        startMenu.SetActive(false);
        timer.enabled = true;
        Time.timeScale = 1;
        startMenuActive = false;
    }
}
