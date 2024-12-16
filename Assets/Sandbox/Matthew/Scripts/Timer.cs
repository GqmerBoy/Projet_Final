using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    private bool _timerActive = true;
    private float _currentTime;
    [SerializeField] private TMP_Text _text;
    // Start is called before the first frame update
    void Start()
    {
        _currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(_timerActive == true){
            _currentTime = _currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(_currentTime);
        _text.text = time.ToString(@"mm\:ss\:ff");
    }

    public void StartTimer(){
        _timerActive = true;
    }

    public void StopTimer(){
        _timerActive = false;
    }
}
