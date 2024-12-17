using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] public GameObject gameOverMenu;

    public bool gameOverMenuActive = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);
        gameOverMenuActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame(){
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
        gameOverMenuActive = true;
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
