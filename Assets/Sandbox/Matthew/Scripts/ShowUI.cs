using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{

    [SerializeField] private GameObject wristMenu;

    private bool menuActive = false;

    // Start is called before the first frame update
    void Start()
    {
        wristMenu.SetActive(false);
    }

    public void ToggleMenu(){
        if(wristMenu.activeInHierarchy == false){
            wristMenu.SetActive(true);
            menuActive = true;
        }

        else{
            wristMenu.SetActive(false);
            menuActive = false;
        }
    }
}
