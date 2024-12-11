using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{

    [SerializeField] private Canvas wrist;
    // Start is called before the first frame update
    void Start()
    {
        wrist.enabled = false;
    }

    public void ToggleMenu(){
        wrist.enabled =! wrist.enabled;
    }
}
